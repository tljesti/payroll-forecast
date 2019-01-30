using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class EmployeeBusinessModel : PersonWithIdAbstractBusinessModel
    {
        public ICollection<DependentBusinessModel> Dependents { get; set; } = new List<DependentBusinessModel>();
    }
}
