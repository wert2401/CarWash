using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.Services.ImageService;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class CustomerCarsController : BaseController<CustomerCar>
    {
        private readonly ICollection<Car> cars;
        private readonly ICollection<Customer> customers;
        private readonly IImageService imageService;

        public CustomerCarsController(IRepositoriesHolder repositoriesHolder, IImageService imageService) : base(repositoriesHolder.CustomerCarRepository)
        {
            cars = repositoriesHolder.CarRepository.GetAll();
            customers = repositoriesHolder.CustomerRepository.GetAll();
            this.imageService = imageService;
        }

        public IActionResult Index()
        {
            CustomerCarIndexViewModel viewModel = new CustomerCarIndexViewModel();
            viewModel.Entities = baseRepository.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CustomerCarSearchParameters customerCarSearchParameters)
        {
            CustomerCarIndexViewModel viewModel = new CustomerCarIndexViewModel();
            viewModel.SearchParameters = customerCarSearchParameters;

            return FindAndOpen(viewModel);
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Create()
        {
            CustomerCarViewModel viewModel = new CustomerCarViewModel();
            viewModel.CarsSelectItems = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cars, "CarId", "Model", viewModel.Entity.CarId);
            viewModel.CustomersSelectItems = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(customers, "CustomerId", "FirstName", viewModel.Entity.CustomerId);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CustomerCarViewModel customerCarViewModel)
        {
            CustomerCar customerCarToCreate = customerCarViewModel.Entity;

            if (customerCarViewModel.ImageFile != null)
                customerCarToCreate.Image = imageService.SaveCustomerCarImg(customerCarViewModel.ImageFile);

            return AddAndRedirectToAction(customerCarToCreate, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            CustomerCarViewModel viewModel = new CustomerCarViewModel();
            viewModel.CarsSelectItems = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cars, "CarId", "Model", viewModel.Entity.CarId);
            viewModel.CustomersSelectItems = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(customers, "CustomerId", "FirstName", viewModel.Entity.CustomerId);

            return GetAndOpen(id, viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CustomerCarViewModel customerCarViewModel)
        {
            CustomerCar customerCarToUpdate = customerCarViewModel.Entity;

            if (customerCarViewModel.ImageFile != null)
                customerCarToUpdate.Image = imageService.SaveCustomerCarImg(customerCarViewModel.ImageFile);

            return UpdateAndRedirectToAction(id, customerCarToUpdate, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(CustomerCar newEntity, ref CustomerCar oldEntity)
        {
            oldEntity.Number = newEntity.Number;
            oldEntity.CustomerId = newEntity.CustomerId;
            oldEntity.CarId = newEntity.CarId;
            oldEntity.Image = newEntity.Image;
            oldEntity.Year = newEntity.Year;
        }
    }
}
