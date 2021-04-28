using lms_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lms_core.Data
{
    public class DbInitializer
    {
        public static void Initialize(CourseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return; 
            }

            var students = new Student[]
            {
            new Student{FirstName="Adik",LastName="Alexander",EnrollmentDate=DateTime.Parse("2015-09-01")},
            new Student{FirstName="Janibek",LastName="Alonso",EnrollmentDate=DateTime.Parse("2012-09-01")},
            new Student{FirstName="Kairat",LastName="Anand",EnrollmentDate=DateTime.Parse("2013-09-01")},
            new Student{FirstName="Bula",LastName="Uragan",EnrollmentDate=DateTime.Parse("2012-09-01")},
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var teachers = new Teacher[]
            {
            new Teacher{FirstName="Erik",LastName="Aserov",HireDate=DateTime.Parse("2009-04-21")},
            new Teacher{FirstName="Erjan",LastName="Erlanov",HireDate=DateTime.Parse("2006-11-05")}
            };
            foreach (Teacher t in teachers)
            {
                context.Teachers.Add(t);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Java EE",Description="Lets get started with java",TotalHours=63},
            new Course{CourseID=4022,Title="Python",Description="Powerfull language for everything",TotalHours=54},
            new Course{CourseID=4041,Title="C#", Description="Microsoft's favorite language! Wanna study?",TotalHours=35},
            new Course{CourseID=1045,Title="PHP",Description="Course for juniors of web developers!",TotalHours=42},
            new Course{CourseID=3141,Title="C++",Description="That one is very hard, but interesting! Come on",TotalHours=78}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var matriculations = new Matriculation[]
            {
            new Matriculation{StudentID=1,CourseID=1050,Grade=100},
            new Matriculation{StudentID=1,CourseID=4022,Grade=75},
            new Matriculation{StudentID=1,CourseID=4041,Grade=80},
            new Matriculation{StudentID=2,CourseID=1045,Grade=79},
            new Matriculation{StudentID=2,CourseID=3141,Grade=82}
            };
            foreach (Matriculation m in matriculations)
            {
                context.Matriculations.Add(m);
            }
            context.SaveChanges();
        }
    }
}
