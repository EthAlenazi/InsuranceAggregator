using Microsoft.AspNetCore.Mvc;

namespace InsuranceAggregator.Controllers
{
    public class PoliciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
