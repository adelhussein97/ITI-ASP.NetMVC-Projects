using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce_MVC_ModelWithAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public HomeController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}