using Arenda.Data;
using Arenda.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Controllers
{
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
                PaymentFrequencySelectList = _db.PaymentFrequencies.Select(i=> new SelectListItem()
                {
                    Text=i.Name,
                    Value=i.Id.ToString()
                }),
                ArendatorSelectList = _db.Arendators.Select(i => new SelectListItem()
                {
                    Text = i.SecondName + " " + i.FirstName + " " + i.LastName,
                    Value = i.Id.ToString()
                }),
                PremiseSelectList = _db.Premises.Select(i => new SelectListItem()
                {
                    Text = i.PremiseNumber.ToString(),
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
            if (obj == null)
            {
                return View("Error");
            }
            else
            {
                _db.Contracts.Add(obj.Contract);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
