namespace CupLeagueGenerator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
