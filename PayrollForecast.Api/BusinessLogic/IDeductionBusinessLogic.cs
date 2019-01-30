using PayrollForecast.Api.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessLogic
{
    public interface IDeductionBusinessLogic
    {
        List<DeductionBusinessModel> CreateDeductionsPerPaymentFromEmployee(EmployeeBusinessModel employee, int paymentsPerYear);
        List<DeductionBusinessModel> CreateDeductionsPerYearFromEmployee(EmployeeBusinessModel employee);
        DeductionBusinessModel CreateDeduction(PersonAbstractBusinessModel person, string deductionType, decimal initialDeduction);
    }
}
