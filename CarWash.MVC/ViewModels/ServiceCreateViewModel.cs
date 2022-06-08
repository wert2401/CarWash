using CarWash.Database.Models;
using CarWash.MVC.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels
{
    public class ServiceCreateViewModel : IViewModel<Service>
    {
        public Service Entity { get; set; } = new Service();
        public SelectList SelectListItems { get; set; }
    }
}
