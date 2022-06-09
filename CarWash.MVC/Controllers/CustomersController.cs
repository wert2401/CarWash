using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IRepositoriesHolder repositoriesHolder) : base(repositoriesHolder.CustomerRepository)
        {
        }

        public IActionResult Index()
        {
            CustomerIndexViewModel viewModel = new CustomerIndexViewModel();
            viewModel.Entities = baseRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CustomerSearchParameters customerSearchParameters)
        {
            CustomerIndexViewModel viewModel = new CustomerIndexViewModel();
            viewModel.SearchParameters = customerSearchParameters;

            return FindAndOpen(viewModel);
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            return AddAndRedirectToAction(customer, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            return GetAndOpen(id);
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            return UpdateAndRedirectToAction(id, customer, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(Customer newEntity, ref Customer oldEntity)
        {
            oldEntity.FirstName = newEntity.FirstName;
            oldEntity.LastName = newEntity.LastName;
            oldEntity.Patronymic = newEntity.Patronymic;
            oldEntity.Email = newEntity.Email;
            oldEntity.Sex = newEntity.Sex;
            oldEntity.IsSendNotify = newEntity.IsSendNotify;
        }
    }
}
