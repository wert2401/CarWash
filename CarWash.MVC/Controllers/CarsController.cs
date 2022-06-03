using CarWash.Database.Models;
using CarWash.Database.Repositories;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.Controllers
{
    public class CarsController : BaseController<IRepository<Car>, Car>
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly ICollection<Brand> brands;

        public CarsController(IRepository<Car> carRepository, IRepository<Brand> brandRepository) : base(carRepository)
        {
            this.brandRepository = brandRepository;
            brands = brandRepository.GetAll();
        }

        public IActionResult Create()
        {
            CarCreateViewModel viewModel = new CarCreateViewModel();

            SelectList brandsSL = new SelectList(brands, "BrandId", "Name", viewModel.Car.BrandId);

            viewModel.BrandsSelectList = brandsSL;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CarCreateViewModel viewModel)
        {
            Car carToAdd = viewModel.Car;

            return AddAndRedirectToAction(carToAdd, RedirectToAction("Details", "Brands", new { id = viewModel.Car.BrandId }));
        }

        public IActionResult Details(int id)
        {
            return GetAndOpen(id);
        }

        public IActionResult Delete(int id)
        {
            return RemoveAndRedirectToAction(id, Redirect(Request.Headers["Referer"].ToString()));
        }

        public IActionResult Edit(int id)
        {
            return GetAndOpen(id);
        }

        [HttpPost]
        public IActionResult Edit(int id, Car car)
        {
            return UpdateAndRedirectToAction(id, car, (car) => RedirectToAction("Edit", "Brands", new { id = car.BrandId}));
        }

        protected override void UpdateFieldsOfEntity(Car newEntity, ref Car oldEntity)
        {
            oldEntity.Model = newEntity.Model;
        }
    }
}
