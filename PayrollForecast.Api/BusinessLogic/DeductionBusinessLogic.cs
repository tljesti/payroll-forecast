using PayrollForecast.Api.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessLogic
{
    public class DeductionBusinessLogic : IDeductionBusinessLogic
    {
        private const decimal _employeeBenefitDeductionPerYear = 1000M; // Cost of benefits per year
        private const decimal _dependentBenefitDeductionPerYear = 500M; // Additional cost of benefits per dependent
        private const char _discountQualifier = 'A'; // Discount is activated if employee/dependent name starts with 'A'
        private const decimal _discountValuePercent = 0.1M; // 10% off

        public List<DeductionBusinessModel> CreateDeductionsPerPaymentFromEmployee(EmployeeBusinessModel employee, int paymentsPerYear)
        {
            var deductions = new List<DeductionBusinessModel>();

            // The cost of benefits is $1000 per year for each employee.  There are 26 paychecks in a year.
            var employeeBenefitDeductionPerPayment = _employeeBenefitDeductionPerYear / paymentsPerYear;
            // Generate Employee Benefit Deduction
            deductions.Add(CreateDeduction(employee, "Employee Benefit", employeeBenefitDeductionPerPayment));

            // The cost of benefits is $500 per year for each dependent.  There are 26 paychecks in a year.
            var dependentBenefitDeductionPerPayment = _dependentBenefitDeductionPerYear / paymentsPerYear;
            // Generate Employee Benefit Deductions
            foreach (var dependent in employee.Dependents)
                deductions.Add(CreateDeduction(dependent, $"Dependent Benefit ({dependent.FirstName} {dependent.LastName})", dependentBenefitDeductionPerPayment));

            return deductions;
        }

        public List<DeductionBusinessModel> CreateDeductionsPerYearFromEmployee(EmployeeBusinessModel employee)
        {
            var deductions = new List<DeductionBusinessModel>();

            // Generate Employee Benefit Deduction
            deductions.Add(CreateDeduction(employee, "Employee Benefit", _employeeBenefitDeductionPerYear));

            // Generate Employee Benefit Deductions
            foreach (var dependent in employee.Dependents)
                deductions.Add(CreateDeduction(dependent, $"Dependent Benefit ({dependent.FirstName} {dependent.LastName})", _dependentBenefitDeductionPerYear));

            return deductions;
        }

        public DeductionBusinessModel CreateDeduction(PersonAbstractBusinessModel person, string deductionType, decimal initialDeduction)
        {
            var deduction = new DeductionBusinessModel()
            {
                Type = deductionType,
                InitialCost = initialDeduction,
                Discount = (person.FirstName.StartsWith(_discountQualifier) || person.LastName.StartsWith(_discountQualifier)) ? _discountValuePercent : 0M
            };
            deduction.TotalCost = deduction.InitialCost - (deduction.InitialCost * deduction.Discount);

            return deduction;
        }
    }
}
