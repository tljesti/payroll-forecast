using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class DeductionBusinessModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public decimal InitialCost { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalCost { get; set; }
    }
}
