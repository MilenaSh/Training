using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlurarsiteDemoCore2.Models;
using PlurarsiteDemoCore2.ViewModels;

namespace PlurarsiteDemoCore2.Controllers
{
    public class IceCreamController : Controller
    {
        private readonly IIceCreamRepository _iceCreamRepository;

        public IceCreamController(IIceCreamRepository iceCreamRepository)
        {
            _iceCreamRepository = iceCreamRepository;
        }

        public IActionResult Index()
        {
            var iceCream = _iceCreamRepository.GetAllIceCream().OrderBy(i => i.Name);

            var iceCreamViewModel = new IceCreamViewModel
            {
                Title = "My icecreams",
                IceCreams = iceCream.ToList()
            };

            return View(iceCreamViewModel);

            //return View();

        }
    }
}
