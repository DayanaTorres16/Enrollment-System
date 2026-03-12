namespace Ejercicio1.Repository
{
    using System.Collections.Generic;
    using Models;

    public interface ICourseRepository
    {
        CourseData AddCourse(CourseData courseData);
        
        CourseData? GetCourse(string code);
        
        List<CourseData> GetAllCourses();
    }
}
