using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class ServiceCategoriesController : BaseController<ServiceCategory>
    {
        public ServiceCategoriesController(IRepositoriesHolder repositoriesHolder) : base(repositoriesHolder.ServiceCategoryRepository)
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
        public IActionResult Create(ServiceCategory serviceCategory)
        {
            return AddAndRedirectToAction(serviceCategory, RedirectToAction("Index"));
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
        public IActionResult Edit(int id, ServiceCategory serviceCategory)
        {
            return UpdateAndRedirectToAction(id, serviceCategory, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(ServiceCategory newEntity, ref ServiceCategory oldEntity)
        {
            oldEntity.Name = newEntity.Name;
        }
    }
}
