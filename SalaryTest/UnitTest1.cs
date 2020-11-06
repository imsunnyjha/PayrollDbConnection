using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlDemo;
using System;

namespace SalaryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UC3_CompareUpdatedSalary()
        {
            SalaryModel model = new SalaryModel()
            {
                salaryId = 23,
                salaryAmount = 10021,
                month = "october",
                employeeId = 1
            };
            EmployeeRepo repo = new EmployeeRepo();
            int actual = repo.UpdateEmployee(model);
            Assert.AreEqual(model.salaryAmount, actual);
        }
        [TestMethod]
        public void GivenEmployeeDetails_AddPayrollDetails()
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeePayroll employeePayroll = new EmployeePayroll()
            {
                employeeName = "Terrisa",
                phoneNumber = "7775568964",
                address = "SA",
                Gender = "F"
            };
            PayrollModel payrollModel = new PayrollModel()
            {
                BasicPay = 5500,
                Deductions = 500,
                IncomeTax = 300
            };

            int employeeId = repo.AddEmployeeToPayroll(payrollModel, employeePayroll);

            Assert.AreEqual(employeePayroll.employeeId, employeeId);
        }
    }
}