using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.Database.Repositories.SearchParameters;
using CarWash.MVC.Services.ImageService;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        private readonly IImageService imageService;

        public EmployeesController(IRepositoriesHolder repositoriesHolder, IImageService imageService) : base(repositoriesHolder.EmployeeRepository)
        {
            this.imageService = imageService;
        }

        public IActionResult Index()
        {
            EmployeeIndexViewModel viewModel = new EmployeeIndexViewModel();
            IEnumerable<Employee> employees = baseRepository.GetAll();
            viewModel.Entities = employees;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(EmployeeSearchParameters employeeSearchParameters)
        {
            EmployeeIndexViewModel employeeIndexViewModel = new EmployeeIndexViewModel();
            employeeIndexViewModel.SearchParameters = employeeSearchParameters;

            return FindAndOpen(employeeIndexViewModel);
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
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            Employee employeeToAdd = employeeViewModel.Entity;

            if (employeeViewModel.ImageFile != null)
            {
                employeeToAdd.Image = imageService.SaveEmployeeImg(employeeViewModel.ImageFile);
            }

            return AddAndRedirectToAction(employeeToAdd, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();

            return GetAndOpen(id, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeViewModel employeeViewModel)
        {
            Employee employeeToUpdate = employeeViewModel.Entity;

            if (employeeViewModel.ImageFile != null)
            {
                employeeToUpdate.Image = imageService.SaveEmployeeImg(employeeViewModel.ImageFile);
            }

            return UpdateAndRedirectToAction(id, employeeToUpdate, RedirectToAction("Index"));
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, RedirectToAction("Index"));
        }
        protected override void UpdateFieldsOfEntity(Employee newEntity, ref Employee oldEntity)
        {
            oldEntity.FirstName = newEntity.FirstName;
            oldEntity.LastName = newEntity.LastName;
            oldEntity.Patronymic = newEntity.Patronymic;
            oldEntity.Image = newEntity.Image;
        }
    }
}
