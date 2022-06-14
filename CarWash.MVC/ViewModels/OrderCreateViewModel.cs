using CarWash.Database.Models;
using CarWash.MVC.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels
{
    public class OrderCreateViewModel : IViewModel<Order>
    {
        public Order Entity { get; set; } = new Order();
        public SelectList ServicesSelectList { get; set; }
        public SelectList CustomerCarsSelectList { get; set; }
        public SelectList EmployeesSelectList { get; set; }
    }
}
