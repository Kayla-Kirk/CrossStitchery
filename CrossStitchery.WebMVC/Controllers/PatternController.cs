using CrossStitchery.Models.Pattern;
using CrossStitchery.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossStitchery.WebMVC.Controllers
{
    public class PatternController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PatternService(userId);
            var model = service.GetPattern();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatternCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePatternService();
            if (service.CreatePattern(model))
            {
                TempData["SaveResult"] = "Pattern inventory updated!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Pattern was not added!");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePatternService();
            var model = svc.GetPatternById(id);
            return View(model);
        }

        private PatternService CreatePatternService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PatternService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePatternService();
            var detail = service.GetPatternById(id);
            var model =
                new PatternEdit
                {
                    PatternId= detail.PatternId,
                    Name=detail.Name,
                    NumberOfColors=detail.NumberOfColors,
                    Level=detail.Level,
                    Height=detail.Height,
                    Width=detail.Width,
                    Backstitching=detail.Backstitching
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatternEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PatternId != id)
            {
                ModelState.AddModelError("", "Id isn't correct!");
                return View(model);
            }
            var service = CreatePatternService();
            if (service.UpdatePattern(model))
            {
                TempData["SaveResult"] = "Pattern inventory was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Pattern inventory could not be updated!");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePatternService();
            var model = svc.GetPatternById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePattern(int id)
        {
            var service = CreatePatternService();
            service.DeletePattern(id);
            TempData["SaveResult"] = "Your pattern was deleted";
            return RedirectToAction("Index");
        }
    }
}