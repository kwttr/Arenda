using Arenda.Data;
using Arenda.Models;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    [Authorize]
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

        //GET - CREATELEGALENTITY
        public IActionResult CreateLegalEntity()
        {
            var obj = new LegalEntityViewModel()
            {
                LegalEntity = new LegalEntity(),
                StreetSelectList = _db.Streets.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                BankSelectList = _db.Banks.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(obj);
        }

        //POST - CREATELEGALENTITY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLegalEntity(LegalEntityViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.LegalEntities.Add(obj.LegalEntity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //View additional Information of legal entity
        public IActionResult ViewAdditionalInformationLE(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.LegalEntities.Find(id);
                if (obj == null)
                {
                    return BadRequest();
                }
                obj.Street = _db.Streets.Find(obj.StreetId);
                obj.Bank = _db.Banks.Find(obj.BankId);
                return View(obj);
            }
        }

        //GET - EDITLEGALENTITY
        public IActionResult EditLegalEntity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.LegalEntities.Find(id);
                if (obj == null)
                {
                    return BadRequest();
                }
                obj.Street = _db.Streets.Find(obj.StreetId);
                obj.Bank = _db.Banks.Find(obj.BankId);
                LegalEntityViewModel legalEntityViewModel = new LegalEntityViewModel()
                {
                    LegalEntity = obj,
                    StreetSelectList = _db.Streets.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    BankSelectList = _db.Banks.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };
                return View(legalEntityViewModel);
            }
        }

        //POST - EDITLEGALENTITY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLegalEntity(LegalEntityViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.LegalEntities.Update(obj.LegalEntity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETELEGALENTITY
        public IActionResult DeleteLegalEntity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.LegalEntities.Find(id);
                if (obj == null)
                {
                    return BadRequest();
                }
                obj.Street = _db.Streets.Find(obj.StreetId);
                obj.Bank = _db.Banks.Find(obj.BankId);
                return View(obj);
            }
        }

        //POST - DELETELEGALENTITY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLegalEntity(LegalEntity obj)
        {
            if (obj != null)
            {
                _db.LegalEntities.Remove(obj);
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
