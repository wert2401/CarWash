using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.Controllers
{
    public class OrdersController : BaseController<Order>
    {
        private readonly ICollection<Service> services;
        private readonly ICollection<CustomerCar> customerCars;
        private readonly ICollection<Employee> employees;
        private readonly ILogger logger;

        public OrdersController(IRepositoriesHolder repositoriesHolder, ILogger<OrdersController> logger) : base(repositoriesHolder.OrderRepository)
        {
            services = repositoriesHolder.ServiceRepository.GetAll();
            customerCars = repositoriesHolder.CustomerCarRepository.GetAll();
            employees = repositoriesHolder.EmployeeRepository.GetAll();
            this.logger = logger;
        }

        public IActionResult Index()
        {
            OrderIndexViewModel viewModel = new OrderIndexViewModel();
            viewModel.Entities = baseRepository.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(OrderSearchParameters orderSearchParameters)
        {
            OrderIndexViewModel viewModel = new OrderIndexViewModel();
            viewModel.SearchParameters = orderSearchParameters;

            return FindAndOpen(viewModel);
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Create()
        {
            OrderCreateViewModel viewModel = new OrderCreateViewModel();
            viewModel.ServicesSelectList = new SelectList(services, "ServiceId", "Name", viewModel.Entity.ServiceId);
            viewModel.CustomerCarsSelectList = new SelectList(customerCars, "CustomerCarId", "Car.Model", viewModel.Entity.CustomerCarId);
            viewModel.EmployeesSelectList = new SelectList(employees, "EmployeeId", "FirstName", viewModel.Entity.EmployeeId);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel orderCreateViewModel)
        {
            Order orderToAdd = orderCreateViewModel.Entity;

            orderToAdd.CustomerCar = customerCars.Where(x => x.CustomerCarId == orderToAdd.CustomerCarId).First();

            if (orderToAdd.CustomerCar.Customer.IsSendNotify == true)
            {
                logger.LogInformation($"Order for {orderToAdd.CustomerCar.Customer.FirstName} {orderToAdd.CustomerCar.Customer.LastName} created");
            }

            return AddAndRedirectToAction(orderToAdd, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            OrderCreateViewModel viewModel = new OrderCreateViewModel();
            viewModel.ServicesSelectList = new SelectList(services, "ServiceId", "Name", viewModel.Entity.ServiceId);
            viewModel.CustomerCarsSelectList = new SelectList(customerCars, "CustomerCarId", "Car.Model", viewModel.Entity.CustomerCarId);
            viewModel.EmployeesSelectList = new SelectList(employees, "EmployeeId", "FirstName", viewModel.Entity.EmployeeId);

            return GetAndOpen(id, viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderCreateViewModel orderCreateViewModel)
        {
            Order orderToUpdate = orderCreateViewModel.Entity;

            return UpdateAndRedirectToAction(id, orderToUpdate, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }

        protected override void UpdateFieldsOfEntity(Order newEntity, ref Order oldEntity)
        {
            oldEntity.ServiceId = newEntity.ServiceId;
            oldEntity.CustomerCarId = newEntity.CustomerCarId;
            oldEntity.EmployeeId = newEntity.EmployeeId;
            oldEntity.Status = newEntity.Status;
            oldEntity.StartDate = newEntity.StartDate;
            oldEntity.EndDate = newEntity.EndDate;
        }
    }
}
