using PayrollForecast.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class PaymentBusinessModel
    {
        public decimal InitialValue { get; set; }

        public ICollection<DeductionBusinessModel> Deductions { get; set; } = new List<DeductionBusinessModel>();

        public decimal Total { get; set; }
    }
}
