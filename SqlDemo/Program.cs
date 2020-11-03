﻿using System;

namespace SqlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sql database connectivity!");

            EmployeeRepo repo = new EmployeeRepo();
            
            EmployeePayroll employeePayroll = new EmployeePayroll();
            employeePayroll.employeeName = "John";
            employeePayroll.basic_pay = 20000;
            employeePayroll.startDate = DateTime.Now;
            employeePayroll.Gender = "M";
            employeePayroll.phoneNumber="7677123446";
            employeePayroll.address="Bangur Rd";
            employeePayroll.department="HR";
            employeePayroll.deductions=1000;
            employeePayroll.taxablePay=19000;
            employeePayroll.tax=1900;
            employeePayroll.netPay=18100;
           

            Console.WriteLine("Displaying All Data........");

            repo.AddEmployee(employeePayroll);
            
            //repo.GetAllEmployee();
        }
    }
}
