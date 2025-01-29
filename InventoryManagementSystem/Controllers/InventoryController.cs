using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class InventoryController : Controller
    {
        // Static list to store inventory items (temporary storage)
        private static List<Inventory> inventoryList = new List<Inventory>
        {
            new Inventory { Id = 1, Name = "Laptop", Quantity = 10, Price = 800.00M },
            new Inventory { Id = 2, Name = "Mouse", Quantity = 50, Price = 20.00M }
        };

        // READ: Display the inventory list
        public IActionResult Index()
        {
            return View(inventoryList);
        }

        // CREATE: Show form to add new item
        public IActionResult Add()
        {
            return View();
        }

        // CREATE: Handle form submission
        [HttpPost]
        public IActionResult Add(Inventory newItem)
        {
            newItem.Id = inventoryList.Count + 1; // Assign unique ID
            inventoryList.Add(newItem);
            return RedirectToAction("Index");
        }

        // UPDATE: Show form to edit item
        public IActionResult Edit(int id)
        {
            var item = inventoryList.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // UPDATE: Handle form submission
        [HttpPost]
        public IActionResult Edit(Inventory updatedItem)
        {
            var item = inventoryList.FirstOrDefault(i => i.Id == updatedItem.Id);
            if (item != null)
            {
                item.Name = updatedItem.Name;
                item.Quantity = updatedItem.Quantity;
                item.Price = updatedItem.Price;
            }
            return RedirectToAction("Index");
        }

        // DELETE: Show confirmation page
        public IActionResult Delete(int id)
        {
            var item = inventoryList.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // DELETE: Handle deletion
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var item = inventoryList.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                inventoryList.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
