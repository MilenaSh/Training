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
        private readonly IIceCreamRepository _iceCreamRepository;

       // private object _iceCreamRepository;

        public HomeController(IPieRepository pieRepository, IIceCreamRepository iceCreamRepository)
        {
            _pieRepository = pieRepository;
            _iceCreamRepository = iceCreamRepository;
        }

        public IActionResult Index()
        {


            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            var iceCream = _iceCreamRepository.GetAllIceCream().OrderBy(p => p.Name);


            var homeViewModel = new HomeViewModel
            {
                Title = "Welcome to Bethanies Pie shop",
                Pies = pies.ToList(),
                IceCream = iceCream.ToList()
            };

            return View(homeViewModel);
        }


    }
}