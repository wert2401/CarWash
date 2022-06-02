using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public bool Sex { get; set; }
        public bool IsSendNotify { get; set; }
        public ICollection<CustomerCar> CustomerCars { get; set; }
    }
}
