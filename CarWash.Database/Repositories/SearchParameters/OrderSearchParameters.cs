using CarWash.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.SearchParameters
{
    public class OrderSearchParameters : ISearchParameters
    {
        public string? Service { get; set; }
        public string? CustomerCar { get; set; }
        public string? Employee { get; set; }
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
