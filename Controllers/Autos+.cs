using Microsoft.AspNetCore.Mvc;

namespace apiautos.Controllers
{
    public class Autos_ : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}