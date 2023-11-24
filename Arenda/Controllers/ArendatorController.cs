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

        //POST - CREATEPHYSICALPERSOT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePhysicalPerson(PhysicalPerson obj)   
        {

            return View();
        }


    }
}
