using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossStitchery.WebMVC.Controllers
{
    public class ShoppingListController : Controller
    {
        // GET: ShoppingList
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShoppingListService(userId);
            var model = service.GetShoppingList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShoppingListCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateAidaService();
            if (service.CreateShoppingList(model))
            {
                TempData["SaveResult"] = "Shopping list was updated!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Shopping list was not added!");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateShoppingListService();
            var model = svc.GetShoppingListById(id);
            return View(model);
        }

        private ShoppingListService CreateShoppingListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShoppingListService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShoppingListService();
            var detail = service.GetShoppingListById(id);
            var model =
                new ShoppingListEdit
                {
                    //AidaId = detail.AidaId,
                    //Count = detail.Count,
                    //Color = detail.Color,
                    //Height = detail.Height,
                    //Width = detail.Width
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShoppingListEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ShoppingListId != id)
            {
                ModelState.AddModelError("", "Id isn't correct!");
                return View(model);
            }
            var service = CreateShoppingListService();
            if (service.UpdateShoppingList(model))
            {
                TempData["SaveResult"] = "Shopping list was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Shopping list could not be updated!");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShoppingListService();
            var model = svc.GetShoppingListById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAida(int id)
        {
            var service = CreateShoppingListService();
            service.DeleteAida(id);
            TempData["SaveResult"] = "Your shopping list was deleted!";
            return RedirectToAction("Index");
        }
    }
}
}