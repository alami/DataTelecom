using Microsoft.AspNetCore.Mvc;

namespace Data.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [ActionName ("index")]
        public IActionResult AdminIndex()
        {
            return View();
        }

        
    }
}
