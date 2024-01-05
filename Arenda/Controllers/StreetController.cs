using Arenda.Data;
using Arenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    public class StreetController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StreetController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Street> objList = _db.Streets;
            return View(objList);
        }

        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            Street obj = new Street();
            if (id == null)
            {
                return View(obj);
            }
            else
            {
                obj = _db.Streets.Find(id);
                if(obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Street obj)
        {
            if(ModelState.IsValid)
            {
                if (obj == null || obj.Id == 0)
                {
                    _db.Streets.Add(obj);
                }
                else
                {
                    _db.Streets.Update(obj);
                }
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var obj = _db.Streets.Find(id);
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Street obj)
        {
            if (obj!=null)
            {
                _db.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
