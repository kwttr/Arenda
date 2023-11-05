using Arenda.Data;
using Arenda.Models;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    public class BuildingController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BuildingController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Building> objList = _db.Buildings.ToList();
            foreach(var obj in objList)
            {
                obj.CityArea = _db.CityAreas.FirstOrDefault(x=>x.Id==obj.CityAreaId);
                obj.Street = _db.Streets.FirstOrDefault(x=>x.Id==obj.StreetId);
            }
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            BuildingViewModel buildingVM = new BuildingViewModel()
            {
                Building = new Building(),
                CityAreaSelectList = _db.CityAreas.Select(i=> new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                StreetSelectList = _db.Streets.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(buildingVM);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BuildingViewModel buldingVM)
        {
            if (ModelState.IsValid)
            {
                _db.Buildings.Add(buldingVM.Building);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //GET - VIEWPREMISES
        public IActionResult ViewPremises(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                BuildingPremisesViewModel buildingPremisesViewModel = new BuildingPremisesViewModel()
                {
                    Building = _db.Buildings.FirstOrDefault(x => x.Id == id),
                    Premises = _db.Premises.Where(x => x.BuildingId == id),
                };
                foreach(var obj in buildingPremisesViewModel.Premises)
                {
                    obj.TypeOfFinishing = _db.TypeOfFinishing.FirstOrDefault(x => x.Id == obj.TypeOfFinishingId);
                }
                return View(buildingPremisesViewModel);
            }
        }

        //GET - CREATEPREMISE
        public IActionResult CreatePremise(int? id)
        {
            PremiseViewModel premiseVM = new PremiseViewModel()
            {
                Premise = new Premise(),
                TypeOfFinishingSelectList = _db.TypeOfFinishing.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                premiseVM.Premise.BuildingId = (int)id;
            }
            return View(premiseVM);
        }

        //POST - CREATEPREMISE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePremise(PremiseViewModel premiseVM)
        {
            if(ModelState.IsValid)
            {
                _db.Premises.Add(premiseVM.Premise);
                _db.SaveChanges();
            }
            else
            {
                return View(premiseVM);
            }
            return RedirectToAction("ViewPremises",new {Id = premiseVM.Premise.BuildingId});
        }
    }
}
