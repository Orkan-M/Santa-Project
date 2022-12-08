using Microsoft.AspNetCore.Mvc;

namespace Santa_Project.Controllers
{
    public class StartingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
