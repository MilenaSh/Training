using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlurarsiteDemoCore2.Models;
using PlurarsiteDemoCore2.ViewModels;

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


            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel
            {
                Title = "Welcome to Bethanies Pie shop",
                Pies = pies.ToList()
            };

            return View(homeViewModel);
        }
    }
}