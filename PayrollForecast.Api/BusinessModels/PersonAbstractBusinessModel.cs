using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public abstract class PersonAbstractBusinessModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
