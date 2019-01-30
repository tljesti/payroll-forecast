using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public abstract class PersonWithIdDtoAbstract : PersonDtoAbstractBase
    {
        public int Id { get; set; }
    }
}
