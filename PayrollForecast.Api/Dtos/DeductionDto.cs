using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Dtos
{
    public class DeductionDto
    {
        public string Label { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal Value { get; set; }
    }
}
