using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollForecast.Api.BusinessLogic;
using PayrollForecast.Api.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollForecast.Test.BusinessLogic
{
    [TestClass]
    public class PaymentBusinessLogicTest
    {
        private EmployeeBusinessModel _testEmployee;
        private PaymentBusinessLogic _paymentBusinessLogic;
        private Mock<DeductionBusinessLogic> _deductionBusinessLogic;

        [TestInitialize]
        public void TestInitialize()
        {
            _testEmployee = new EmployeeBusinessModel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            _deductionBusinessLogic = new Mock<DeductionBusinessLogic>();
            _paymentBusinessLogic = new PaymentBusinessLogic(_deductionBusinessLogic.Object);
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithNoANoDependents_ShouldEqualExpected()
        {
            var expectedResult = 51000M; // (26 paychecks * $2000) - $1000
            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithANoDependents_ShouldEqualExpectedWithDiscount()
        {
            _testEmployee.FirstName = "Anna";
            var expectedResult = 51100M; // ($52000) - $900

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithLastNameANoDependents_ShouldEqualExpectedWithDiscount()
        {
            _testEmployee.LastName = "A'Doe";
            var expectedResult = 51100M; // ($52000) - $900

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithFirstAndLastANoDependents_ShouldEqualExpectedWithDiscountOnce()
        {
            _testEmployee.FirstName = "Anna";
            _testEmployee.FirstName = "A'Doe";
            var expectedResult = 51100M; // ($52000) - $900

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithNoAOneDependent_ShouldEqualExpectedWithDependentDeduction()
        {
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Tom", LastName = "Doe" });
            var expectedResult = 50500; // ($52000) - $1000 - ($500)

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithNoATwoDependents_ShouldEqualExpectedWithTwoDependentDeductions()
        {
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Tom", LastName = "Doe" });
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Janet", LastName = "Doe" });
            var expectedResult = 50000; // ($52000) - $1000 - ($500 - $500)

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithNoAOneDependentWithA_ShouldEqualExpectedWithOneDependentDeductionWithDiscount()
        {
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Amy", LastName = "Doe" });
            var expectedResult = 50550; // ($52000) - $1000 - ($450)

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithNoATwoDependentsWithOneA_ShouldEqualExpectedWithOneDependentDeductionWithDiscountOnOne()
        {
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Amy", LastName = "Doe" });
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Janet", LastName = "Doe" });
            var expectedResult = 50050; // ($52000) - $1000 - ($450 - $500)

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }

        [TestMethod]
        public void GetYearlyCostForEmployee_EmployeeWithATwoDependentsWithOneA_ShouldEqualExpectedWithOneDependentDeductionWithDiscountOnOneAndEmployeeDiscount()
        {
            _testEmployee.FirstName = "Anna";
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Amy", LastName = "Doe" });
            _testEmployee.Dependents.Add(new DependentBusinessModel { FirstName = "Janet", LastName = "Doe" });
            var expectedResult = 50150; // ($52000) - $900 - ($450 - $500)

            var actualResult = _paymentBusinessLogic.GetYearlyPaymentForEmployee(_testEmployee);

            Assert.AreEqual(expectedResult, actualResult, "Amounts do not match");
        }
    }
}
