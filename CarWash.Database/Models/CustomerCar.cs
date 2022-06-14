using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class CustomerCar : IModel
    {
        public int CustomerCarId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public string? Image { get; set; }
        public ICollection<Order>? Orders { get; set; }

        [NotMapped]
        public int Id { get => CustomerCarId; }

    }
}
