using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public abstract class DeductionAbstractBusinessModel
    {
        public abstract string DeductionType { get; }
        public abstract decimal Cost { get; set; }
    }
}
