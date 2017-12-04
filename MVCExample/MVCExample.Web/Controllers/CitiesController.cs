using MVCExample.Infrastructure;
using MVCExample.Web.Models.Cities;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExample.Services.Contracts;

namespace MVCExample.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService citiesService;

        public CitiesController(ICityService citiesService)
        {
            this.citiesService = citiesService;
        }

        public ActionResult Index()
        {
            var cities = this.citiesService.All()
                         .To<CityViewModel>()
                         .ToList();

            return View(cities);

            // return View();

        }

        public ActionResult Details(Guid id)
        {
            var city = this.citiesService.GetById(id);

            var mapper = AutoMapperConfiguration.Configuration.CreateMapper();

            var cityViewModel = mapper.Map<CityDetailedViewModel>(city);

            return this.View(cityViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CityCreateViewModel model)
        {
            var newCityServiceCreateModel = new CityServiceCreateModel()
            {
                Name = model.Name,
                Population = model.Population
            };

            this.citiesService.Create(newCityServiceCreateModel);
            return this.RedirectToAction("Index");

        }

        public ActionResult GetCities(string pattern)
        {
            var result = this.citiesService.Filtered(pattern)
                .To<CityDropDownCompleteViewModel>();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult Create(SuperHeroeCreateViewModel model)
        //{
        //    var newSuperHeroeServiceCreateModel = new SuperHeroServiceCreateModel()
        //    {
        //        Name = model.Name,
        //        CityName = model.CityName,
        //        SecretIdentityName = model.SecretIdentityName,
        //        SecretIdentityage = model.SecretIdentityage
        //    };

        //    this.superheroService.Create(newSuperHeroeServiceCreateModel);
        //    return this.RedirectToAction("Index");
        //}


    }
}


