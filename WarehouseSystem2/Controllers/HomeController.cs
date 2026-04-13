using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Data;

namespace WarehouseSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly WarehouseRepository _repo;

        public HomeController(WarehouseRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("GebruikerNaam") == null)
                return RedirectToAction("Login", "Account");

            ViewBag.Naam = HttpContext.Session.GetString("GebruikerNaam");
            ViewBag.Email = HttpContext.Session.GetString("GebruikerEmail");
            ViewBag.Medewerkers = _repo.GetMedewerkerCount();
            ViewBag.Producten = _repo.GetProductCount();
            return View();
        }
    }
}