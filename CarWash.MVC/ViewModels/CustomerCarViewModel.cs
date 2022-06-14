using CarWash.Database.Models;
using CarWash.MVC.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels
{
    public class CustomerCarViewModel : IViewModel<CustomerCar>
    {
        public CustomerCar Entity { get; set; } = new CustomerCar();
        public SelectList CarsSelectItems { get; set; }
        public SelectList CustomersSelectItems { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
