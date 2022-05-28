using Microsoft.AspNetCore.Mvc;

namespace CupLeagueGenerator.Controllers
{
    public class SaveController : Controller
    {
        public IActionResult Saves()
        {
            return View();
        }
    }
}
