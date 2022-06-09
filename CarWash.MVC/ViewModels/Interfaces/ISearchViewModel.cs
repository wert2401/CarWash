using CarWash.Database.Models.Intefaces;
using CarWash.Database.Repositories.Interfaces;

namespace CarWash.MVC.ViewModels.Interfaces
{
    public interface ISearchViewModel<T> where T : IModel
    {
        public IEnumerable<T> Entities { get; set; }
        public ISearchParameters SearchParameters { get; set; }
    }
}
