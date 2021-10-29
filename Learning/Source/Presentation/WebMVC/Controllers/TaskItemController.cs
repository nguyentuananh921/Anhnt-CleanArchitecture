using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public TaskItemController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var taskItems = await _db.TaskItems.ToListAsync();
            return View(taskItems);

        }
        public IActionResult Create()
        {
            return View(new TaskItem());
        }

        [HttpPost]
        public IActionResult Create(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                _db.Add(model);                
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            return View(_db.TaskItems.FirstOrDefault(a => a.Id == Id));
        }

        [HttpPost]
        public IActionResult Edit(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                var editModel = _db.TaskItems.Find(model.Id);
                editModel.TaskName = model.TaskName;
                editModel.IsCompleted = model.IsCompleted;
                //if (editModel.IsCompleted)
                //{
                //    await _emailService.SendEmailAsync("Kevin@test.com", "KC@test.com", "Task Was Completed", $"Task {editModel.Id} Was Completed on {DateTime.Now}");
                //}
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            return View(_db.TaskItems.FirstOrDefault(a => a.Id == Id));
        }

        [HttpPost]
        public IActionResult Delete(TaskItem model)
        {
            var deleteModel = _db.TaskItems.Find(model.Id);
            _db.Remove(deleteModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
