using MVCExample.Infrastructure;
using MVCExample.Services.Contracts;
using MVCExample.Services.Models;
using MVCExample.Web.Models.Superheroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCExample.Web.Controllers
{
    public class SuperheroesController : Controller
    {
        private readonly ISuperheroService superheroService;

        public SuperheroesController(ISuperheroService superheroService)
        {
            this.superheroService = superheroService;
        }



        // GET: Superheroes
        public ActionResult Index()
        {
            var heroes = this.superheroService.All()
                .To<SuperheroViewModel>()
                .ToList();

            return View(heroes);
        }
        /*
         * /superhero/details/id:guid
         */
        public ActionResult Details(Guid id)
        {
            var heroe = this.superheroService.GetById(id);

            var mapper = AutoMapperConfiguration.Configuration.CreateMapper();

            var heroeViewModel = mapper.Map<SuperHeroeDetailedViewModel>(heroe);

            return this.View(heroeViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(SuperHeroeCreateViewModel model)
        {
            var newSuperHeroeServiceCreateModel = new SuperHeroServiceCreateEditModel()
            {
                Name = model.Name,
                CityName = model.CityName,
                SecretIdentityName = model.SecretIdentityName,
                SecretIdentityage = model.SecretIdentityage
            };

            this.superheroService.Create(newSuperHeroeServiceCreateModel);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            var superHero = this.superheroService.GetById(id);

            var model = new SuperHeroeUpdateViewModel
            {
                Id = superHero.Id,
                Name = superHero.Name,
                SecretIdentityName = superHero.SecretIdentity.Name,
                SecretIdentityage = superHero.SecretIdentity.Age,
                CityName = superHero.City.Name
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Update(SuperHeroeUpdateViewModel model)
        {

            var serviceModel = new SuperHeroServiceCreateEditModel()
            {
                Id = model.Id,
                Name = model.Name,
                SecretIdentityName = model.SecretIdentityName,
                SecretIdentityage = model.SecretIdentityage,
                CityName = model.CityName
            };

            this.superheroService.Update(serviceModel);
            //var newSuperHeroeServiceUpdateModel = new SuperHeroServiceUpdateModel()
            //{
            //    Name = model.Name,
            //    SecretIdentityName = model.SecretIdentityName,
            //    SecretIdentiyAge = model.SecretIdentityage,
                
            //};

            //this.superheroService.Update(newSuperHeroeServiceUpdateModel);
            return this.RedirectToAction("Index");
        }

    }
}