using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public abstract class PersonDtoAbstractBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
