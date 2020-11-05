using System;

namespace SqlDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Sql database connectivity!");

            EmployeeRepo repo               = new EmployeeRepo();
            EmployeePayroll employeePayroll = new EmployeePayroll();
            
            employeePayroll.employeeName    = "John";
            employeePayroll.basic_pay       = 20000;
            employeePayroll.startDate       = DateTime.Now;
            employeePayroll.Gender          = "M";
            employeePayroll.phoneNumber     = "7677123446";
            employeePayroll.address         = "Bangur Rd";
            employeePayroll.department      = "HR";
            employeePayroll.deductions      = 1000;
            employeePayroll.taxablePay      = 19000;
            employeePayroll.tax             = 1900;
            employeePayroll.netPay          = 18100;
            Console.WriteLine("Displaying All Data........");

            
            //repo.AddEmployee(employeePayroll);
            
            Console.WriteLine("Retrieving Employee from date range.......");
            employeePayroll.startDate = DateTime.Parse("2020-09-05");
            employeePayroll.endDate = DateTime.Parse("2021-06-20");  
            repo.RetrieveEmployeeBasedOnStartDate(employeePayroll);

            Console.WriteLine("Retrieving Sum Avg Min Max from Employee"); 
            repo.UsingDatabaseFunction(employeePayroll);
        }
    }
}