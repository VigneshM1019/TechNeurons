using Microsoft.AspNetCore.Mvc;
using System;
using TechNeuronsProj.Models.Domain;


namespace TechNeuronsProj.Controllers
{
    public class TaskController : Controller
    {
        private readonly DatabaseContext _ctx;
        public TaskController (DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Display ()
        {
            var task = _ctx.Task.ToList();
            return View(task);
        }
        public IActionResult Create () 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Domain.Task task)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Task.Add(task);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("Create");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!";
                return View();
            }
        }
        
        public ActionResult Edit (int Id)
        {
            var task = _ctx.Task.Find(Id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(Models.Domain.Task task)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Task.Update(task);
                _ctx.SaveChanges();
                return RedirectToAction("Display");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not update!!!";
                return View();
            }

        }
        public ActionResult Delete (int Id)
        {
            try
            {
                var task = _ctx.Task.Find(Id);
                if (task != null)
                {
                    _ctx.Task.Remove(task);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("Display");
        }
    }
}
