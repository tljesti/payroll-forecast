using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class DependentBusinessModel : PersonWithIdAbstractBusinessModel
    {
        public int EmployeeId { get; set; }
    }
}
