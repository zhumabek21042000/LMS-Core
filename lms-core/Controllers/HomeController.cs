using lms_core.Data;
using lms_core.Models;
using lms_core.Models.CourseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lms_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly CourseContext _context;

        public HomeController(CourseContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> About()
        {
            IQueryable<MatriculationDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new MatriculationDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
