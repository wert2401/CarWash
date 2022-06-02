using CarWash.Database.Models;
using CarWash.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IRepository<Brand> repository;

        public BrandsController(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            repository.Add(brand);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        public IActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Brand brand)
        {
            brand.BrandId = id;
            repository.Update(brand);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repository.Remove(repository.Get(id));
            return RedirectToAction("Index");
        }
    }
}
