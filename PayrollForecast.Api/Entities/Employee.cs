using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollForecast.Api.Entities
{
    public class Employee : PersonWithId
    {
        public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
