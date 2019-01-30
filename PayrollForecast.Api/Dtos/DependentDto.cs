using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public class DependentDto : PersonWithIdDtoAbstract
    {
        public int EmployeeId { get; set; }
    }
}
