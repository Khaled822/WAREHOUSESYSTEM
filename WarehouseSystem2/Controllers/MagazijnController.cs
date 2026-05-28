using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Data;
using WarehouseSystem.Models;

namespace WarehouseSystem.Controllers
{
    public class MagazijnController : Controller
    {
        private readonly WarehouseRepository _repository;

        public MagazijnController(WarehouseRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Detail(int id)
        {
            if (HttpContext.Session.GetString("GebruikerNaam") == null)
                return RedirectToAction("Login", "Account");

            // Get warehouse products - using sample data for now
            var products = GetWarehouseProducts(id);

            ViewData["WarehouseId"] = id;
            ViewData["WarehouseName"] = $"Warehouse {id}";
            ViewData["Capacity"] = 85; // Sample capacity percentage
            ViewData["Products"] = products;

            return View();
        }

        private List<Product> GetWarehouseProducts(int warehouseId)
        {
            // Sample data - replace with actual database calls
            var products = new List<Product>
            {
                new Product { Id = 1, Naam = "Widget A", Voorraad = 500, MagazijnId = warehouseId },
                new Product { Id = 2, Naam = "Gizmo B", Voorraad = 150, MagazijnId = warehouseId },
                new Product { Id = 3, Naam = "Component C", Voorraad = 800, MagazijnId = warehouseId },
                new Product { Id = 4, Naam = "Widget D", Voorraad = 300, MagazijnId = warehouseId },
                new Product { Id = 5, Naam = "Widget E", Voorraad = 150, MagazijnId = warehouseId },
                new Product { Id = 6, Naam = "Widget F", Voorraad = 800, MagazijnId = warehouseId }
            };

            return products;
        }
    }
}
