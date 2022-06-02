using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class CustomerCar
    {
        public int CustomerCarId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public string? Image { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
