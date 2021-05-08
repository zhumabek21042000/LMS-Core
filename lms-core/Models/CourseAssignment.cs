using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lms_core.Models
{
    public class CourseAssignment
    {
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
//public async Task<IActionResult> Index(
//           string sortOrder,
//           string currentFilter,
//           string searchString,
//           int? pageNumber)
//{
//    ViewData["CurrentSort"] = sortOrder;
//    ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
//    ViewData["TotalHoursSortParm"] = sortOrder == "TotalHours" ? "th_desc" : "TotalHours";
//    if (searchString != null)
//    {
//        pageNumber = 1;
//    }
//    else
//    {
//        searchString = currentFilter;
//    }

//    ViewData["CurrentFilter"] = searchString;
//    var courses = from s in _context.Courses
//                  select s;
//    if (!String.IsNullOrEmpty(searchString))
//    {
//        courses = courses.Where(s => s.Title.Contains(searchString)
//                               || s.Description.Contains(searchString));
//    }
//    switch (sortOrder)
//    {
//        case "title_desc":
//            courses = courses.OrderByDescending(s => s.Title);
//            break;
//        case "TotalHours":
//            courses = courses.OrderBy(s => s.TotalHours);
//            break;
//        case "th_desc":
//            courses = courses.OrderByDescending(s => s.TotalHours);
//            break;
//        default:
//            courses = courses.OrderBy(s => s.Title);
//            break;
//    }
//    int pageSize = 3;
//    return View(await PaginatedList<Course>.CreateAsync(courses.AsNoTracking(), pageNumber ?? 1, pageSize));
//}
//@model PaginatedList<lms_core.Models.Course>

//@{
//    ViewData["Title"] = "Index";
//}

//< h1 > Index </ h1 >

//< p >
//    < a asp - action = "Create" > Create New </ a >
//       </ p >
//       < form asp - action = "Index" method = "get" >
            
//                < div class= "form-actions no-color" >
             
//                     < p >
//                         Find by name: < input type = "text" name = "SearchString" value = "@ViewData["CurrentFilter "]" />
                     
//                                 < input type = "submit" value = "Search" class= "btn btn-default" /> |
                          
//                                      < a asp - action = "Index" > Back to Full List</a>
//        </p>
//    </div>
//</form>
//<table class= "table" >
//    < thead >
//        < tr >
//            < th >
//                < a asp - action = "Index" asp - route - sortOrder = "@ViewData["TitleSortParm "]" asp - route - currentFilter = "@ViewData["CurrentFilter "]" > Title </ a >
                   
//                               </ th >
                   
//                               < th >
//                                   Description
//                               </ th >
                   
//                               < th >
                   
//                                   < a asp - action = "Index" asp - route - sortOrder = "@ViewData["TotalHoursSortParm "]" asp - route - currentFilter = "@ViewData["CurrentFilter "]" > Total hours </ a >
                                        
//                                                    </ th >
                                        
//                                                    < th ></ th >
                                        
//                                                </ tr >
                                        
//                                            </ thead >
                                        
//                                            < tbody >
//                                                @foreach(var item in Model)
//        {
//            < tr >
//                < td >
//                    @Html.DisplayFor(modelItem => item.Title)
//                </ td >
//                < td >
//                    @Html.DisplayFor(modelItem => item.Description)
//                </ td >
//                < td >
//                    @Html.DisplayFor(modelItem => item.TotalHours)
//                </ td >
//                < td >
//                    < a asp - action = "Edit" asp - route - id = "@item.CourseID" > Edit </ a > |
     
//                         < a asp - action = "Details" asp - route - id = "@item.CourseID" > Details </ a > |
          
//                              < a asp - action = "Delete" asp - route - id = "@item.CourseID" > Delete </ a >
               
//                               </ td >
               
//                           </ tr >
//        }
//    </ tbody >
//</ table >
//@{
//    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
//    var nextDisabled = !Model.HasNextPage ? "disabled" : "";
//}

//< a asp - action = "Index"
//   asp - route - sortOrder = "@ViewData["CurrentSort "]"
//   asp - route - pageNumber = "@(Model.PageIndex - 1)"
//   asp - route - currentFilter = "@ViewData["CurrentFilter "]"
//   class= "btn btn-default @prevDisabled" >
//    Previous
//</ a >
//< a asp - action = "Index"
//   asp - route - sortOrder = "@ViewData["CurrentSort "]"
//   asp - route - pageNumber = "@(Model.PageIndex + 1)"
//   asp - route - currentFilter = "@ViewData["CurrentFilter "]"
//   class= "btn btn-default @nextDisabled" >
//    Next
//</ a >