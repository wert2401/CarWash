using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Models
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
