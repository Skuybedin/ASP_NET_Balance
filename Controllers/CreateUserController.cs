using BalanceTest.Data;
using BalanceTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalanceTest.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CreateUserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CreateUser> objList = _db.CreateUser;
            return View(objList);
        }

        // GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUser obj)
        {
            if (ModelState.IsValid)
            {
                _db.CreateUser.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.CreateUser.Find(id);

            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateUser obj)
        {
            if (ModelState.IsValid)
            {
                _db.CreateUser.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _db.CreateUser.Find(id);

            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CreateUser.Find(id);

            if (obj == null) return NotFound();

            _db.CreateUser.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
