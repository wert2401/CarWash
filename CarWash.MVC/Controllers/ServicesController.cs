using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.Controllers
{
    public class ServicesController : BaseController<Service>
    {
        private readonly ICollection<ServiceCategory> serviceCategories; 

        public ServicesController(IRepositoriesHolder repositoriesHolder) : base(repositoriesHolder.ServiceRepository)
        {
            serviceCategories = repositoriesHolder.ServiceCategoryRepository.GetAll();
        }

        public IActionResult Index()
        {
            return View(baseRepository.GetAll());
        }

        public IActionResult Create()
        {
            ServiceCreateViewModel viewModel = new ServiceCreateViewModel();
            viewModel.SelectListItems = new SelectList(serviceCategories, "ServiceCategoryId", "Name", viewModel.Entity.ServiceCategoryId);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ServiceCreateViewModel viewModel)
        {
            Service serviceToAdd = viewModel.Entity;
            return AddAndRedirectToAction(serviceToAdd, RedirectToAction("Index"));
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Edit(int id)
        {
            ServiceCreateViewModel viewModel = new ServiceCreateViewModel();
            viewModel.SelectListItems = new SelectList(serviceCategories, "ServiceCategoryId", "Name", viewModel.Entity.ServiceCategoryId);

            return GetAndOpen(id, viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ServiceCreateViewModel viewModel)
        {
            Service serviceToUpdate = viewModel.Entity;
            return UpdateAndRedirectToAction(id, serviceToUpdate, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(Service newEntity, ref Service oldEntity)
        {
            oldEntity.Name = newEntity.Name;
            oldEntity.Duration = newEntity.Duration;
            oldEntity.Price = newEntity.Price;
            oldEntity.ServiceCategoryId = newEntity.ServiceCategoryId;
        }
    }
}
