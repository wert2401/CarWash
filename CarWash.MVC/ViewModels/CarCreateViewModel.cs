using CarWash.Database.Models;
using CarWash.MVC.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels
{
    public class CarCreateViewModel : IViewModel<Car>
    {
        public Car Entity { get; set; } = new Car();
        public SelectList SelectListItems { get; set; }
    }
}
