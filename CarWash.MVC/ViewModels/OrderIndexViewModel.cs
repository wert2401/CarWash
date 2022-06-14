using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.ViewModels.Interfaces;

namespace CarWash.MVC.ViewModels
{
    public class OrderIndexViewModel : IViewModel<Order>, ISearchViewModel<Order>
    {
        public Order Entity { get; set; }
        public IEnumerable<Order> Entities { get; set; }
        public ISearchParameters SearchParameters { get; set; }
    }
}
