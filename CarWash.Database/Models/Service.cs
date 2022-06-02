using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
