using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Customer : IModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public bool Sex { get; set; }
        public bool IsSendNotify { get; set; }
        public ICollection<CustomerCar> CustomerCars { get; set; }

        [NotMapped]
        public int Id { get => CustomerId; }
    }
}
