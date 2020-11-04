using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlDemo;

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
    }
}