using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class ServiceCategory : IModel
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Service> Services { get; set; }

        [NotMapped]
        public int Id { get => ServiceCategoryId; }
    }
}
