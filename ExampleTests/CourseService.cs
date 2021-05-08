using lms_core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ExampleTests
{
    public class CourseService
    {
        [Fact]
        public async Task Test1()
        {
            Course course = new Course();
            course.Title = "python";
            Assert.Equal("python", course.Title);
        }

   

        [Fact]
        public async Task GetCoursesTest()
        {
            var courses = new List<Course>
            {
                new Course() { Title = "test Course 1" },
                new Course() { Title = "test Course 2" },
            };
            Assert.Collection(courses, course => Assert.Contains("test", course.Title),
                course => Assert.Contains("Course 2", course.Title));
           
        }

        [Fact]
        public async Task SearchTest()
        {
            Course course = new Course();
            course.Description = " Checking of the test";

            Assert.NotNull(course);
        }
    }
}
