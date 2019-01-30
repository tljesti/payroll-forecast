using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class EmployeeWithYearlyPaymentBusinessModel : EmployeeBusinessModel
    {
        public decimal YearlyPayment { get; set; }
    }
}
