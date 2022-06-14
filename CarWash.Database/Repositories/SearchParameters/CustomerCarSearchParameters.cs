using CarWash.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.SearchParameters
{
    public class CustomerCarSearchParameters : ISearchParameters
    {
        public string? CarModel { get; set; }
        public string? CustomerName { get; set; }
        public int? Year { get; set; }
        public string? Number { get; set; }
    }
}
