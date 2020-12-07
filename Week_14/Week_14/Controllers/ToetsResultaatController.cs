using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week_13.Controllers
{
    public class ToetsResultaatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public string AddResult()
        {
            // TODO This is a test please implement properly.
            return "You can only see this logged in.";
        }
    }
}