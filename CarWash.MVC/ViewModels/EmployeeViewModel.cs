using CarWash.Database.Models;
using CarWash.MVC.ViewModels.Interfaces;

namespace CarWash.MVC.ViewModels
{
    public class EmployeeViewModel : IViewModel<Employee>
    {
        public Employee Entity { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
