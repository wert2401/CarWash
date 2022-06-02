using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
