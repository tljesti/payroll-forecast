using AutoMapper;
using PayrollForecast.Api.BusinessModels;
using PayrollForecast.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.BusinessLogic
{
    public class EmployeeBusinessLogic : IEmployeeBusinessLogic
    {
        private const int _paychecksPerYear = 26; // Number of paychecks in a year
        private const decimal _employeeBenefitDeduction = 1000M; // Cost of benefits per year
        private const decimal _dependentBenefitDeduction = 500M; // Additional cost of benefits per dependent

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentBusinessLogic _paymentBusinessLogic;

        public EmployeeBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, IPaymentBusinessLogic paymentBusinessLogic)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentBusinessLogic = paymentBusinessLogic;
        }

        public async Task<IEnumerable<EmployeeWithYearlyPaymentBusinessModel>> GetEmployeesWithYearlyPayment()
        {
            var employees = _mapper.Map<IEnumerable<EmployeeWithYearlyPaymentBusinessModel>>(await _unitOfWork.Employees.GetAll()).ToList();
            employees.ForEach(e => e.YearlyPayment = _paymentBusinessLogic.GetYearlyPaymentForEmployee(e));

            return employees;
        }

        public async Task<EmployeeWithYearlyPaymentBusinessModel> GetEmployeeByIdWithYearlyPayment(int employeeId)
        {
            var employee = _mapper.Map<EmployeeWithYearlyPaymentBusinessModel>(await _unitOfWork.Employees.GetById(employeeId));
            employee.YearlyPayment = _paymentBusinessLogic.GetYearlyPaymentForEmployee(employee);

            return employee;
        }

        public async Task<EmployeeWithYearlyPaymentAndSummaryBusinessModel> GetEmployeeByIdWithYearlyPaymentAndSummary(int employeeId)
        {
            var employee = _mapper.Map<EmployeeWithYearlyPaymentAndSummaryBusinessModel>(await _unitOfWork.Employees.GetById(employeeId));
            employee.YearlyPaymentSummary = _paymentBusinessLogic.GetYearlyPaymentSummaryForEmployee(employee);
            employee.YearlyPayment = _paymentBusinessLogic.GetYearlyPaymentForEmployee(employee);

            return employee;
        }
    }
}
