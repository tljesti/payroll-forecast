using PayrollForecast.Api.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessLogic
{
    public class PaymentBusinessLogic : IPaymentBusinessLogic
    {        
        private const int _paymentsPerYear = 26; // Number of paychecks in a year
        private const decimal _initialPaymentValue = 2000M; // Value of paycheck before deductions
        private readonly IDeductionBusinessLogic _deductionBusinessLogic;

        public PaymentBusinessLogic(IDeductionBusinessLogic deductionBusinessLogic)
        {
            _deductionBusinessLogic = deductionBusinessLogic;
        }

        public List<PaymentBusinessModel> GeneratePaymentsForEmployee(EmployeeBusinessModel employee)
        {
            var payments = new List<PaymentBusinessModel>();

            for (int i = 0; i < _paymentsPerYear; i++)
            {
                var paycheck = new PaymentBusinessModel
                {
                    InitialValue = _initialPaymentValue,
                    Deductions = _deductionBusinessLogic.CreateDeductionsPerPaymentFromEmployee(employee, _paymentsPerYear)
                };
                paycheck.Total = CalculatePaycheckTotal(paycheck);

                payments.Add(paycheck);
            }

            return payments;
        }

        public decimal CalculatePaycheckTotal(PaymentBusinessModel paycheck)
        {
            return paycheck.InitialValue - paycheck.Deductions.Sum(d => d.TotalCost);
        }

        public decimal GetYearlyPaymentForEmployee(EmployeeBusinessModel employee)
        {
            var payments = GeneratePaymentsForEmployee(employee);

            return CalculatePaymentSum(payments);
        }

        public YearlyPaymentSummaryBusinessModel GetYearlyPaymentSummaryForEmployee(EmployeeWithYearlyPaymentAndSummaryBusinessModel employee)
        {
            var payments = GeneratePaymentsForEmployee(employee);
            var summary = new YearlyPaymentSummaryBusinessModel()
            {
                InitialValue = Math.Round(payments.Sum(p => p.InitialValue)),
                Deductions = _deductionBusinessLogic.CreateDeductionsPerYearFromEmployee(employee),
                Total = CalculatePaymentSum(payments)
            };
            return summary;
        }

        public decimal CalculatePaymentSum(IEnumerable<PaymentBusinessModel> payments)
        {
            return Math.Round(payments.Sum(p => p.Total), 2);
        }
    }
}
