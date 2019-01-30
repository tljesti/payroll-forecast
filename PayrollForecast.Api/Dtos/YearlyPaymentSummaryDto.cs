using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public class YearlyPaymentSummaryDto
    {
        public decimal InitialValue { get; set; }

        public ICollection<DeductionDto> Deductions { get; set; } = new List<DeductionDto>();

        public decimal Total { get; set; }
    }
}
