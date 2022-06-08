using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Order : IModel
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int CustomerCarId { get; set; }
        public CustomerCar CustomerCar { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [NotMapped]
        public int Id { get => OrderId; }
    }
}
