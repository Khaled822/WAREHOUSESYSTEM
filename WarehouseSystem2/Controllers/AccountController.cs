using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Domain.Entities;
using WarehouseSystem.Domain.Services;

namespace WarehouseSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGebruikerService _service;

        public AccountController(IGebruikerService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("GebruikerNaam") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var gebruiker = _service.Login(model.Email, model.Wachtwoord);
            if (gebruiker != null)
            {
                HttpContext.Session.SetString("GebruikerNaam", gebruiker.Naam!);
                HttpContext.Session.SetString("GebruikerEmail", gebruiker.Email!);
                HttpContext.Session.SetInt32("GebruikerId", gebruiker.Id);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Fout = "Ongeldig e-mailadres of wachtwoord.";
            return View(model);
        }

        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("GebruikerNaam") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model.Wachtwoord != model.WachtwoordBevestig)
            {
                ViewBag.Fout = "Wachtwoorden komen niet overeen.";
                return View(model);
            }

            try
            {
                _service.RegistreerGebruiker(model.Naam, model.Email, model.Wachtwoord);
                TempData["Success"] = "Account aangemaakt! Je kunt nu inloggen.";
                return RedirectToAction("Login");
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Fout = ex.Message;
                return View(model);
            }
            catch (ArgumentException ex)
            {
                ViewBag.Fout = ex.Message;
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}