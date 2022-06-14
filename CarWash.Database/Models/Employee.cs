using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Employee : IModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Image { get; set; }
        public ICollection<Order>? Orders { get; set; }

        [NotMapped]
        public int Id { get => EmployeeId; }

    }
}
