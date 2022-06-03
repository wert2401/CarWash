using CarWash.Database.Models;
using CarWash.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class BrandsController : BaseController<IRepository<Brand>, Brand>
    {
        public BrandsController(IRepository<Brand> brandRepository) : base(brandRepository)
        {
        }

        public IActionResult Index()
        {
            return View(baseRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            return AddAndRedirectToAction(brand, RedirectToAction("Index"));
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Edit(int id)
        {
            return GetAndOpen(id);
        }

        [HttpPost]
        public IActionResult Edit(int id, Brand brand)
        {
            return UpdateAndRedirectToAction(id, brand, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(Brand newEntity, ref Brand oldEntity)
        {
            oldEntity.Name = newEntity.Name;
        }
    }
}
