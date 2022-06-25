using BalanceTest.Data;
using BalanceTest.Models;
using BalanceTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalanceTest.Controllers
{
    public class AddBalanceController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AddBalanceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<AddBalance> objList = _db.AddBalance.Include(x => x.CreateUser);

            return View(objList);
        }

        // GET ADD
        public IActionResult Add()
        {
            AddBalanceVM addBalanceVM = new AddBalanceVM() //Получение всех категорий из базы данных
            {
                AddBalance = new AddBalance(),
                UsersSelectList = _db.CreateUser.Select(x => new SelectListItem
                {
                    Text = x.Login,
                    Value = x.Id.ToString()
                })
            };

            return View(addBalanceVM);
        }

        // POST ADD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddBalance addBalance)
        {
            if (ModelState.IsValid)
            {
                _db.AddBalance.Add(addBalance);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addBalance);
        }

        // POST CONFIRM
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(int? id, int? userId)
        {
            var addBalanceData = _db.AddBalance.Find(id);
            var createUserData = _db.CreateUser.Find(userId);

            if (addBalanceData == null || createUserData == null) return NotFound();

            addBalanceData.Status = Statuses.Approved;
            addBalanceData.UpdateData = DateTime.Now.ToString();
            createUserData.Balance += addBalanceData.Balance;

            _db.AddBalance.Update(addBalanceData);
            _db.CreateUser.Update(createUserData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST DECLINE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Decline(int? id)
        {
            var addBalanceData = _db.AddBalance.Find(id);

            if (addBalanceData == null) return NotFound();

            addBalanceData.Status = Statuses.Rejected;
            addBalanceData.UpdateData = DateTime.Now.ToString();

            _db.AddBalance.Update(addBalanceData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST REFUND
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Refund(int? id, int? userId)
        {
            var addBalanceData = _db.AddBalance.Find(id);
            var createUserData = _db.CreateUser.Find(userId);

            if (addBalanceData == null || createUserData == null) return NotFound();

            addBalanceData.UpdateData = DateTime.Now.ToString();
            addBalanceData.Status = Statuses.Refund;
            createUserData.Balance -= addBalanceData.Balance;

            _db.AddBalance.Update(addBalanceData);
            _db.CreateUser.Update(createUserData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var addBalanceData = _db.AddBalance.Include(x => x.CreateUser).FirstOrDefault(x => x.Id == id);

            if (addBalanceData == null) return NotFound();

            return View(addBalanceData);
        }

        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var addBalanceData = _db.AddBalance.Find(id);

            if (addBalanceData == null) return NotFound();

            _db.AddBalance.Remove(addBalanceData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
