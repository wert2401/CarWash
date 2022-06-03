using CarWash.Database.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels
{
    public class CarCreateViewModel
    {
        public Car Car { get; set; } = new Car();
        public SelectList BrandsSelectList { get; set; }
    }
}
