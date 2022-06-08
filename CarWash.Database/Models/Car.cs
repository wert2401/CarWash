using CarWash.Database.Models.Intefaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Database.Models
{
    public class Car : IModel
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [NotMapped]
        public int Id { get => CarId; }
    }
}
