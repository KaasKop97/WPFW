using Microsoft.AspNetCore.Mvc;

namespace Studenten.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}