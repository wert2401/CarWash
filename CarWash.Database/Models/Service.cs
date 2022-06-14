using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Service : IModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public ICollection<Order>? Orders { get; set; }


        [NotMapped]
        public int Id { get => ServiceId; }
    }
}
