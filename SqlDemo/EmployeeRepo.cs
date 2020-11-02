using System.Data.SqlClient;
using System;

namespace SqlDemo
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(LocalDb)\sunnydb;Initial Catalog=Payroll_Service;Integrated Security=True";
        readonly SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"SELECT * FROM employee_payroll;";

                    //define SqlCommand Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.employeeId = dr.GetInt32(0);
                            employeePayroll.employeeName = dr.GetString(1);
                            employeePayroll.basicPay = dr.GetDecimal(2);
                            employeePayroll.startDate = dr.GetDateTime(3);
                            employeePayroll.Gender = dr.GetString(4);
                            employeePayroll.phoneNumber = dr.GetString(5);
                            employeePayroll.address = dr.GetString(6);
                            employeePayroll.department = dr.GetString(7);
                            employeePayroll.deductions = dr.GetDecimal(8);
                            employeePayroll.taxablePay = dr.GetDecimal(9);
                            employeePayroll.tax = dr.GetDecimal(10);
                            employeePayroll.netPay = dr.GetDecimal(11);
                            
                            //Display retrieved record
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}",employeePayroll.employeeId,employeePayroll.employeeName,employeePayroll.phoneNumber,employeePayroll.address,employeePayroll.department,employeePayroll.Gender,employeePayroll.phoneNumber);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found!");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
