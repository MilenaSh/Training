using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlurarsiteDemoCore2.Models;

namespace PlurarsiteDemoCore2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {

            ViewBag.Title = "Pie overview";

            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            return View();
        }
    }
}