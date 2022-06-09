using CarWash.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Database.Repositories.SearchParameters
{
    public class CustomerSearchParameters : ISearchParameters
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Patronymic { get; set; } = null;
        public string? Email { get; set; } = null;
        public bool? Sex { get; set; } = null;
        public bool? IsSendNotify { get; set; } = null;
    }
}
