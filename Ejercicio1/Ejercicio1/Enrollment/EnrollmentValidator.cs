namespace Ejercicio1.Enrollment;

public class EnrollmentValidator
{
    public bool ValidateEnrollment(Enrollment enrollment)
    {
        return enrollment.Student != null &&
               enrollment.Courses != null &&
               enrollment.Courses.Count > 0;
    }
}
