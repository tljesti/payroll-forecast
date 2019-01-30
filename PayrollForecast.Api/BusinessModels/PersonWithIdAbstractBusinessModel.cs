using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class PersonWithIdAbstractBusinessModel : PersonAbstractBusinessModel
    {
        public int Id { get; set; }
    }
}
