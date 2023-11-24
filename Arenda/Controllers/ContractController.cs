using Arenda.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View(objList);
        }
    }
}
