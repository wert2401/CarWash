using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Brand : IModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }

        [NotMapped]
        public int Id { get => BrandId; }
    }
}
