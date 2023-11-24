using Arenda.Data;
using Arenda.Models;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    public class ArendatorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ArendatorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ArendatorViewModel arendatorVM = new()
            {
                LegalEntities = _db.LegalEntities,
                PhysicalPersons = _db.PhysicalPersons
            };

            return View(arendatorVM);
        }

        public IActionResult OpenModal()
        {
            var result = PartialView("_Modal");
            return PartialView("_Modal");
        }

        //GET - CREATEPHYSICALPERSON
        public IActionResult CreatePhysicalPerson()
        {
            var obj = new PhysicalPerson();
            return View(obj);
        }

        //POST - CREATEPHYSICALPERSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePhysicalPerson(PhysicalPerson obj)   
        {
            if(ModelState.IsValid)
            {
                _db.PhysicalPersons.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //View additional Information of physical person
        public IActionResult ViewAdditionalInformationPP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.PhysicalPersons.Find(id);
                return View(obj);
            }
        }

        //GET - EDITPHYSICALPERSON
        public IActionResult EditPhysicalPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.PhysicalPersons.Find(id);
                return View(obj);
            }
        }

        //POST - EDITPHYSICALPERSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPhysicalPerson(PhysicalPerson obj)
        {
            if (ModelState.IsValid)
            {
                _db.PhysicalPersons.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETEPHYSICALPERSON
        public IActionResult DeletePhysicalPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj =_db.PhysicalPersons.Find(id);
                return View(obj);
            }
        }

        //POST - DELETEPHYSICALPERSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePhysicalPerson(PhysicalPerson obj)
        {
            if (obj != null)
            {
                _db.PhysicalPersons.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
    }
}
