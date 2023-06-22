using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers
{
    public class InstallmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
