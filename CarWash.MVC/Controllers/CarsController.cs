using CarWash.Database.Models;
using CarWash.Database.Repositories;
using CarWash.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly IRepository<Car> carRepository;
        private readonly IRepository<Brand> brandRepository;
        private ICollection<Brand> brands;

        public CarsController(IRepository<Car> carRepository, IRepository<Brand> brandRepository)
        {
            this.carRepository = carRepository;
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
            carRepository.Add(carToAdd);

            return RedirectToAction("Details", "Brands", new { id = viewModel.Car.BrandId });
        }

        public IActionResult Details(int id)
        {
            return View(carRepository.Get(id));
        }

        public IActionResult Delete(int id)
        {
            carRepository.Remove(carRepository.Get(id));
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Edit(int id)
        {
            return View(carRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Car car)
        {
            Car carToUpdate = carRepository.Get(id);

            carToUpdate.Model = car.Model;

            carRepository.Update(carToUpdate);

            return RedirectToAction("Edit", "Brands", new { id = carToUpdate.BrandId });
        }
    }
}
