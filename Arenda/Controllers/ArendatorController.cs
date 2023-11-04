using Arenda.Data;
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
            ArendatorViewModel arendatorVM = new ArendatorViewModel()
            {
                LegalEntities = _db.LegalEntities,
                PhysicalPersons = _db.PhysicalPersons
            };

            return View(arendatorVM);
        }
    }
}
