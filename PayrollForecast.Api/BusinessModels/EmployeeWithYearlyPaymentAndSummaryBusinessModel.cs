using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class EmployeeWithYearlyPaymentAndSummaryBusinessModel : EmployeeWithYearlyPaymentBusinessModel
    {
        public YearlyPaymentSummaryBusinessModel YearlyPaymentSummary { get; set; }
    }
}
