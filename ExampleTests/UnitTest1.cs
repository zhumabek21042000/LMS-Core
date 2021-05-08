using lms_core.Models;
using System;
using Xunit;

namespace ExampleTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Course course = new Course();
            course.Description = "This course is best course";
            Assert.EndsWith("course", course.Description);
        }
    }
}
