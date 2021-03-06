﻿using System;

namespace SqlDemo
{
    public class EmployeePayroll
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string Gender { get; set; }
        public decimal basic_pay { get; set; }
        public decimal deductions { get; set; }
        public decimal taxablePay { get; set; }
        public decimal tax { get; set; }
        public decimal netPay { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}