using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class DependentDeductionBusinessModel : DeductionAbstractBusinessModel
    {
        private readonly string _deductionType;
        private decimal _cost;

        public DependentDeductionBusinessModel(decimal cost)
        {
            _deductionType = "Dependent Benefit";
            _cost = cost;
        }

        public override string DeductionType => _deductionType;

        public override decimal Cost { get => _cost; set => _cost = value; }
    }
}
