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


            var departments = new Department[]
           {
                new Department { Name = "Engineering",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeacherID  = teachers.Single( i => i.LastName == "Nurmukhanov").ID },
                new Department { Name = "Business", Budget = 100000,
                    StartDate = DateTime.Parse("2017-09-25"),
                    TeacherID  = teachers.Single( i => i.LastName == "Zhuanyshev").ID },
                new Department { Name = "ICT", Budget = 350000,
                    StartDate = DateTime.Parse("2015-05-21"),
                    TeacherID  = teachers.Single( i => i.LastName == "Erdenov").ID },
                new Department { Name = "Computer Science",   Budget = 100000,
                    StartDate = DateTime.Parse("2017-11-01"),
                    TeacherID  = teachers.Single( i => i.LastName == "Kapezov").ID }
           };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();



            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Java EE",Description="Lets get started with java",TotalHours=63
            ,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID},
            new Course{CourseID=4022,Title="Python",Description="Powerfull language for everything",TotalHours=54
            ,DepartmentID = departments.Single( s => s.Name == "ICT").DepartmentID},
            new Course{CourseID=4041,Title="C#", Description="Microsoft's favorite language! Wanna study?",TotalHours=35
            ,DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID},
            new Course{CourseID=1045,Title="PHP",Description="Course for juniors of web developers!",TotalHours=42
            ,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID},
            new Course{CourseID=3141,Title="C++",Description="That one is very hard, but interesting! Come on",TotalHours=78
            ,DepartmentID = departments.Single( s => s.Name == "Business").DepartmentID}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var matriculations = new Matriculation[]
            {
            new Matriculation{StudentID = students.Single(s => s.LastName == "Uragan").ID,
                    CourseID = courses.Single(c => c.Title == "PHP" ).CourseID,Grade=100},
            new Matriculation{StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Java EE" ).CourseID,Grade=75},
            new Matriculation{StudentID = students.Single(s => s.LastName == "Uragan").ID,
                    CourseID = courses.Single(c => c.Title == "Python" ).CourseID,Grade=80},
            new Matriculation{StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "C++" ).CourseID,Grade=79},
            new Matriculation{StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "C#" ).CourseID,Grade=82}
            };
            foreach (Matriculation m in matriculations)
            {
                var check = context.Matriculations.Where(
                    s =>
                            s.Student.ID == m.StudentID &&
                            s.Course.CourseID == m.CourseID).SingleOrDefault();
                if (check == null)
                {
                    context.Matriculations.Add(m);
                }
               
            }
            context.SaveChanges();

            


        }
    }
}
