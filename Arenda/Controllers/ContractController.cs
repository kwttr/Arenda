using Arenda.Data;
using Arenda.Models;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContractController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objList = _db.Contracts.ToList();
            foreach(var obj in objList)
            {
                obj.Arendator = _db.Arendators.Find(obj.ArendatorId);
            }
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            ContractViewModel obj = new ContractViewModel()
            {
                Contract = new Models.Contract(),
                PaymentFrequencySelectList = _db.PaymentFrequencies.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ArendatorSelectList = _db.Arendators.Select(i => new SelectListItem()
                {
                    Text = i.SecondName + " " + i.FirstName + " " + i.LastName,
                    Value = i.Id.ToString()
                })
            };

            return View(obj);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContractViewModel obj)
        {
            ModelState.Remove("Contract.rentedPremises");
            if (ModelState.IsValid)
            {
                foreach (var premise in obj.Premises)
                {
                    if (premise == null) return Create();
                    premise.Contract = obj.Contract;
                    _db.RentedPremises.Add(premise);
                }
                obj.Contract.rentedPremises = obj.Premises;
                _db.Contracts.Add(obj.Contract);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return Create();
        }

        public IActionResult GetRentedPremiseForm(int index)
        {
            RentedPremiseViewModel viewModel = new RentedPremiseViewModel()
            {
                Premises = _db.Premises.Select(i => new SelectListItem()
                {
                    Text = $"{i.PremiseNumber} {i.Building.NumberOfBuilding} {i.Building.Street.Name}",
                    Value = i.Id.ToString()
                }),
                RentPurposes = _db.RentPurposes.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                Index = index
            };
            return PartialView("_RentedPremisePartial", viewModel);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                ContractEditViewModel contract = new()
                {
                    Contract = _db.Contracts.Find(id),
                    PaymentFrequencySelectList = _db.PaymentFrequencies.Select(i => new SelectListItem()
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    ArendatorSelectList = _db.Arendators.Select(i => new SelectListItem()
                    {
                        Text = i.SecondName + " " + i.FirstName + " " + i.LastName,
                        Value = i.Id.ToString()
                    }),
                    Premises = _db.RentedPremises.Where(x => x.ContractId == id).ToList(),
                };
                int i = 0;
                foreach(var item in contract.Premises)
                {
                    contract.rentedPremiseViewModels.Add(new RentedPremiseViewModel()
                    {
                        Premises = _db.Premises.Select(i => new SelectListItem()
                        {
                            Text = $"{i.PremiseNumber} {i.Building.NumberOfBuilding} {i.Building.Street.Name}",
                            Value = i.Id.ToString()
                        }),
                        RentPurposes = _db.RentPurposes.Select(i => new SelectListItem()
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }),
                        Index = i,
                        RentedPremise = item
                    });
                    i++;
                }
                return View(contract);
            }
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContractEditViewModel obj)
        {
            ModelState.Remove("Contract.rentedPremises");

            //УДАЛЕНИЕ
            int j = 0;
            for (int i = 0; i < obj.Premises.Count(); i++)
            {
                if (ModelState[$"Premises[{j}].RentalPeriod"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    ModelState.Remove($"Premises[{j}].RentalPeriod");
                    ModelState.Remove($"Premises[{j}].Id");
                    if (obj.Premises[i].Id != 0) _db.RentedPremises.Remove(obj.Premises[i]);
                    obj.Premises.Remove(obj.Premises[i]);
                    _db.SaveChanges();
                    i--;
                }
                j++;
            }

            if (ModelState.IsValid)
            {
                //Добавление или редактирование
                foreach(var item in obj.Premises)
                {
                    item.Contract = obj.Contract;
                    if (item.Id == 0)
                    {
                        _db.RentedPremises.Add(item);
                        obj.Contract.rentedPremises.Add(item);
                    }
                    else
                    {
                        _db.RentedPremises.Update(item);
                    }
                }
                obj.Contract.rentedPremises = obj.Premises;
                _db.Contracts.Update(obj.Contract);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                ContractEditViewModel obj = new()
                {
                    Contract = _db.Contracts.Find(id),
                    Premises = _db.RentedPremises.Where(p => p.ContractId == id).ToList(),
                    PaymentFrequencySelectList = _db.PaymentFrequencies.Select(i => new SelectListItem()
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    ArendatorSelectList = _db.Arendators.Select(i => new SelectListItem()
                    {
                        Text = i.SecondName + " " + i.FirstName + " " + i.LastName,
                        Value = i.Id.ToString()
                    }),
                };
                int i = 0;
                foreach(var item in obj.Premises)
                {
                    obj.rentedPremiseViewModels.Add(new RentedPremiseViewModel()
                    {
                        Premises = _db.Premises.Select(i => new SelectListItem()
                        {
                            Text = $"{i.PremiseNumber} {i.Building.NumberOfBuilding} {i.Building.Street.Name}",
                            Value = i.Id.ToString()
                        }),
                        RentPurposes = _db.RentPurposes.Select(i => new SelectListItem()
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }),
                        Index = i,
                        RentedPremise = item
                    });
                    i++;
                }
                return View(obj);
            }
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ContractViewModel obj)
        {
            if (obj == null) return BadRequest();
            if (obj.Contract != null) _db.Contracts.Remove(obj.Contract);
            else return BadRequest();
            return RedirectToAction("Index");
        }

        //GET - VIEWPENALTIES
        public IActionResult ViewPenalties(int? id)
        { 
            if(id == null) return NotFound();
            ContractPenaltyViewModel vm = new()
            {
                Contract = _db.Contracts.Find(id),
                Penalties = _db.Penalty.Where(x=>x.ContractId == id)
            };
            return View(vm);
        }

        //GET - ADDPENALTY
        public IActionResult AddPenalty(int? id)
        {
            if(id == null) return NotFound();
            Penalty obj = new() { ContractId = (int)id};
            return View(obj);
        }

        //POST - ADDPENALTY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPenalty(Penalty obj)
        {
            if (obj == null) return NotFound();
            if (ModelState.IsValid)
            {
                _db.Penalty.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewPenalties", new { Id = obj.ContractId });
        }

        //GET - EDITPENALTY
        public IActionResult EditPenalty(int? id)
        {
            if (id == null) return NotFound();
            var obj = _db.Penalty.Find(id);
            return View(obj);
        }

        //POST - EDITPENALTY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPenalty(Penalty obj)
        {
            if (obj == null) return NotFound();
            if (ModelState.IsValid)
            {
                _db.Penalty.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewPenalties", new { Id = obj.ContractId });
        }

        //GET - DELETEPENALTY
        public IActionResult DeletePenalty(int? id)
        {
            if (id == null) return NotFound();
            var obj = _db.Penalty.Find(id);
            return View(obj);
        }

        //POST - DELETEPENALTY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePenalty(Penalty obj)
        {
            if (obj == null) return NotFound();
            if (ModelState.IsValid)
            {
                _db.Penalty.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewPenalties", new { Id = obj.ContractId });
        }
    }
}
