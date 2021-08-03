using CrossStitchery.Models;
using CrossStitchery.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossStitchery.WebMVC.Controllers
{
    public class FlossController : Controller
    {
        // GET: Floss
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FlossService(userId);
            var model = service.GetFloss();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlossCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateFlossService();
            if (service.CreateFloss(model))
            {
                TempData["SaveResult"] = "Floss inventory updated!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Floss was not added!");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFlossService();
            var model = svc.GetFlossById(id);
            return View(model);
        }

        private FlossService CreateFlossService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FlossService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFlossService();
            var detail = service.GetFlossById(id);
            var model =
                new FlossEdit
                {
                    FlossId = detail.FlossId,
                    ColorNumber = detail.ColorNumber,
                    ColorName = detail.ColorName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FlossEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.FlossId != id)
            {
                ModelState.AddModelError("", "Id isn't correct!");
                return View(model);
            }
            var service = CreateFlossService();
            if (service.UpdateFloss(model))
            {
                TempData["SaveResult"] = "Floss inventory was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Floss inventory could not be updated!");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFlossService();
            var model = svc.GetFlossById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFloss(int id)
        {
            var service = CreateFlossService();
            service.DeleteFloss(id);
            TempData["SaveResult"] = "Your floss was deleted";
            return RedirectToAction("Index");
        }
    }
}