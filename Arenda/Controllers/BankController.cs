using Arenda.Data;
using Arenda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    [Authorize]
    public class BankController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BankController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Bank> objList = _db.Banks;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            Bank obj = new Bank();
            return View(obj);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bank obj)
        {
            if (ModelState.IsValid)
            {
                _db.Banks.Add(obj);
                _db.SaveChanges();
            }
            else
            {
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                Bank obj = _db.Banks.FirstOrDefault(b => b.Id == id);
                return View(obj);
            }
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Bank obj)
        {
            if (obj!=null)
            {
                _db.Banks.Remove(obj);
                _db.SaveChanges();
            }
            else
            {
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                Bank obj = _db.Banks.FirstOrDefault(b=>b.Id==id);
                return View(obj);
            }
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bank obj)
        {
            if (ModelState.IsValid)
            {
                _db.Banks.Update(obj);
                _db.SaveChanges();
            }
            else { return View(obj); }
            return RedirectToAction("Index");
        }
    }
}
