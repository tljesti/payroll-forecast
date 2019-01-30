using PayrollForecast.Api.BusinessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessLogic
{
    public interface IEmployeeBusinessLogic
    {
        Task<EmployeeWithYearlyPaymentBusinessModel> GetEmployeeByIdWithYearlyPayment(int employeeId);
        Task<EmployeeWithYearlyPaymentAndSummaryBusinessModel> GetEmployeeByIdWithYearlyPaymentAndSummary(int employeeId);
        Task<IEnumerable<EmployeeWithYearlyPaymentBusinessModel>> GetEmployeesWithYearlyPayment();
    }
}
