using Microsoft.AspNetCore.Mvc;

namespace Arenda.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
