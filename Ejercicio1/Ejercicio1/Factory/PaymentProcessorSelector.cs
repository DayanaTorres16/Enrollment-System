using Ejercicio1.Enrollment;
using Ejercicio1.Enum;
using Ejercicio1.Interfaces;

namespace Ejercicio1.Factory;

public class PaymentProcessorSelector : IPaymentProcessor
{
    private readonly FullPaymentProcessor _fullProcessor;
    private readonly PartialPaymentProcessor _partialProcessor;

    public string PaymentType => "Selected Payment Processor";
    
    public PaymentProcessorSelector(
        FullPaymentProcessor fullProcessor,
        PartialPaymentProcessor partialProcessor)
    {
        _fullProcessor = fullProcessor;
        _partialProcessor = partialProcessor;
    }

    public bool CanProcessPayment(decimal amount, IPayment payment, out string errorMessage)
    {
        return SelectProcessor(payment).CanProcessPayment(amount, payment, out errorMessage);
    }
    public void ProcessPayment(decimal amount, IPayment payment)
    {
        IPaymentProcessor selectedProcessor = SelectProcessor(payment);
        selectedProcessor.ProcessPayment(amount, payment);
    }
    private IPaymentProcessor SelectProcessor(IPayment payment)
    {
        if (payment is Payment concretePayment)
        {
            var student = concretePayment.GetEnrollmentContext().Student;
            
            if (student.Type == StudentType.Exchange || student.Semester == 1)
            {
                return _fullProcessor;
            }
        }
        
        return _partialProcessor;
    }
}