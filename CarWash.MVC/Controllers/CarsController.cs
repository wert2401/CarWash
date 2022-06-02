using CarWash.Database.Models;
using CarWash.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly IRepository<Car> repository;

        public CarsController(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public IActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        public IActionResult Delete(int id)
        {
            repository.Remove(repository.Get(id));
            return Redirect(Request.PathBase);
        }

        public IActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Car car)
        {
            Car carOld = repository.Get(id);

            car.CarId = carOld.CarId;
            car.BrandId = carOld.BrandId;
            car.Brand = carOld.Brand;

            repository.Update(car);

            return RedirectToAction("Details", "Brands", new { id = car.BrandId });
        }
    }
}
