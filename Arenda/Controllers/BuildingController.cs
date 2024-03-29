﻿using Arenda.Data;
using Arenda.Models;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Controllers
{
    [Authorize]
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

        //GET - EDITPREMISE
        public IActionResult EditPremise(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                PremiseViewModel obj = new PremiseViewModel()
                {
                    Premise = _db.Premises.FirstOrDefault(i => i.Id == id),
                    TypeOfFinishingSelectList = _db.TypeOfFinishing.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };
                return View(obj);
            }
        }

        //POST - EDITPREMISE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPremise(PremiseViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Premises.Update(obj.Premise);
                _db.SaveChanges();
            }
            var url = Url.Action("ViewPremises", new { id = obj.Premise.BuildingId });
            url = url.Replace("%2F", "/");
            return Redirect(url);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                var obj = _db.Buildings.Where(b => b.Id == id)
                    .Include(b => b.Street)
                    .Include(b => b.CityArea)
                    .FirstOrDefault();
                if (obj == null) return NotFound();
                return View(obj);
            }
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Building obj)
        {
            if (obj == null) return NotFound();
            else
            {
                _db.Buildings.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                BuildingViewModel buildingVM = new BuildingViewModel()
                {
                    Building = _db.Buildings.Find(id),
                    CityAreaSelectList = _db.CityAreas.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
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
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BuildingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _db.Buildings.Update(vm.Building);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        //GET - DELETEPREMISE
        public IActionResult DeletePremise(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                var obj = _db.Premises.Where(p=>p.Id == id)
                    .Include(p=>p.TypeOfFinishing)
                    .FirstOrDefault();
                if (obj == null) return NotFound();
                return View(obj);
            }
        }

        //POST - DELETEPREMISE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePremise(Premise obj)
        {
            if (obj == null) return NotFound();
            else
            {
                _db.Premises.Remove(obj);
                _db.SaveChanges();
                var url = Url.Action("ViewPremises", new { id = obj.BuildingId });
                url = url.Replace("%2F", "/");
                return Redirect(url);
            }

        }
    }
}
