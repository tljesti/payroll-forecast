using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public class EmployeeDto : PersonWithIdDtoAbstract
    {
        public ICollection<DependentDto> Dependents { get; set; } = new List<DependentDto>();        
    }
}
