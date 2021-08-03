using CrossStitchery.Models.Aida;
using CrossStitchery.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossStitchery.WebMVC.Controllers
{
    public class AidaController : Controller
    {
        // GET: Aida
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AidaService(userId);
            var model = service.GetAida();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AidaCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateAidaService();
            if (service.CreateAida(model))
            {
                TempData["SaveResult"] = "Aida inventory updated!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Aida was not added!");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAidaService();
            var model = svc.GetAidaById(id);
            return View(model);
        }

        private AidaService CreateAidaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AidaService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAidaService();
            var detail = service.GetAidaById(id);
            var model =
                new AidaEdit
                {
                    AidaId = detail.AidaId,
                    Count = detail.Count,
                    Color = detail.Color,
                    Height = detail.Height,
                    Width = detail.Width
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AidaEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.AidaId != id)
            {
                ModelState.AddModelError("", "Id isn't correct!");
                return View(model);
            }
            var service = CreateAidaService();
            if (service.UpdateAida(model))
            {
                TempData["SaveResult"] = "Aida inventory was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Aida inventory could not be updated!");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAidaService();
            var model = svc.GetAidaById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAida(int id)
        {
            var service = CreateAidaService();
            service.DeleteAida(id);
            TempData["SaveResult"] = "Your aida was deleted!";
            return RedirectToAction("Index");
        }
    }
}