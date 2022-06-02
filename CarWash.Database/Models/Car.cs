using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
