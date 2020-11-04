using System.Data.SqlClient;
using System;
using System.Data;


namespace SqlDemo
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(LocalDb)\sunnydb;Initial Catalog=Payroll_Service;Integrated Security=True";
        //private string connectionstring;
        public SqlConnection connection = new SqlConnection(connectionString);

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
                            employeePayroll.basic_pay = dr.GetDecimal(2);
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

                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeePayroll.employeeId, employeePayroll.employeeName, employeePayroll.phoneNumber, employeePayroll.address, employeePayroll.department, employeePayroll.Gender, employeePayroll.phoneNumber);

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
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeePayroll payroll)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeeDetail", this.connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", payroll.employeeName);
                    command.Parameters.AddWithValue("@basic_pay", payroll.basic_pay);
                    command.Parameters.AddWithValue("@start_date", payroll.startDate);
                    command.Parameters.AddWithValue("@Gender", payroll.Gender);
                    command.Parameters.AddWithValue("@phonenumber", payroll.phoneNumber);
                    command.Parameters.AddWithValue("@address", payroll.address);
                    command.Parameters.AddWithValue("@department", payroll.department);
                    command.Parameters.AddWithValue("@Deductions", payroll.deductions);
                    command.Parameters.AddWithValue("@taxable_pay", payroll.taxablePay);
                    command.Parameters.AddWithValue("@income_tax", payroll.tax);
                    command.Parameters.AddWithValue("@net_pay", payroll.netPay);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public int UpdateEmployee(SalaryModel payroll)
        {
            int salary = 0;
            try
            {
                using (connection)
                {
                    connection = new SqlConnection(connectionString);
                    SalaryModel displayModel = new SalaryModel();

                    SqlCommand command = new SqlCommand("spUpdateEmployeePayroll", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@salaryId", payroll.salaryId);
                    command.Parameters.AddWithValue("@salaryAmt", payroll.salaryAmount);
                    command.Parameters.AddWithValue("@month", payroll.month);
                    command.Parameters.AddWithValue("@empId", payroll.employeeId);
                    command.Parameters.AddWithValue("@designation", payroll.designation);
                    command.Parameters.AddWithValue("@empName", payroll.employeeName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            displayModel.employeeId = reader.GetInt32(0);
                            displayModel.salaryId = reader.GetInt32(1);
                            displayModel.salaryAmount = reader.GetInt32(2);
                            displayModel.month = reader.GetString(3);
                            displayModel.employeeName = reader.GetString(4);
                            displayModel.designation = reader.GetString(5); 
                            salary = displayModel.salaryAmount;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found!");
                    }
                    reader.Close();
                    return salary;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
        public void RetrieveEmployeeBasedOnStartDate(EmployeePayroll payroll)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spRetrieveEmployeeBasedOnStartDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@sdate", payroll.startDate);
                command.Parameters.AddWithValue("@edate", payroll.endDate);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payroll.employeeId = reader.GetInt32(0);
                        payroll.employeeName = reader.GetString(1);
                        payroll.address = reader.GetString(2);
                        payroll.department = reader.GetString(3);
                        payroll.basic_pay = reader.GetDecimal(4);
                        payroll.startDate = reader.GetDateTime(5);
                        payroll.endDate = reader.GetDateTime(6);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", payroll.employeeId, payroll.employeeName, payroll.address, payroll.department, payroll.basic_pay, payroll.startDate, payroll.endDate);
                    }
                }
                else
                {
                    Console.WriteLine("Rows doesn't exist!");
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}