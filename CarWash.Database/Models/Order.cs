using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class Order
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
    }
}
