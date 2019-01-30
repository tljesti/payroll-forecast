using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public class EmployeeWithYearlyPaymentAndSummaryDto : EmployeeWithYearlyPaymentDto
    {
        public YearlyPaymentSummaryDto YearlyPaymentSummary { get; set; }
    }
}
