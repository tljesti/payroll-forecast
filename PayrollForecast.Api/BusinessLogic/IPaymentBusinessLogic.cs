using PayrollForecast.Api.BusinessModels;
using System.Collections.Generic;

namespace PayrollForecast.Api.BusinessLogic
{
    public interface IPaymentBusinessLogic
    {
        List<PaymentBusinessModel> GeneratePaymentsForEmployee(EmployeeBusinessModel employee);
        decimal GetYearlyPaymentForEmployee(EmployeeBusinessModel employee);
        YearlyPaymentSummaryBusinessModel GetYearlyPaymentSummaryForEmployee(EmployeeWithYearlyPaymentAndSummaryBusinessModel employee);
    }
}
