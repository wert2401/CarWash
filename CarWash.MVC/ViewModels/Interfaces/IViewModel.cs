using CarWash.Database.Models.Intefaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWash.MVC.ViewModels.Interfaces
{
    public interface IViewModel<T> where T : IModel
    {
        public T Entity { get; set; }
    }
}
