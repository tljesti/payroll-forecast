using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessModels
{
    public class EmployeeDeductionBusinessModel : DeductionAbstractBusinessModel
    {
        private readonly string _deductionType;
        private decimal _cost;

        public EmployeeDeductionBusinessModel(decimal cost)
        {
            _deductionType = "Employee Benefit";
            _cost = cost;
        }

        public override string DeductionType { get => _deductionType; }
        public override decimal Cost { get => _cost; set => _cost = value; }
    }
}
