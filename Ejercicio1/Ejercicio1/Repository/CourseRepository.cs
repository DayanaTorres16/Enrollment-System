namespace Ejercicio1.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class CourseRepository : ICourseRepository
    {
        private readonly List<CourseData> courses;
        
        public CourseRepository(List<CourseData> courses)
        {
            this.courses = courses;
        }
        
        public CourseData AddCourse(CourseData courseData)
        {
            this.courses.Add(courseData);
            return courseData;
        }

        public CourseData? GetCourse(string code)
        {
            return this.courses.FirstOrDefault(c => c.Code == code) ?? null;
        }

        public List<CourseData> GetAllCourses()
        {
            return this.courses;
        }
    }
}
