using System;

namespace SqlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sql database connectivity!");

            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployee();
        }
    }
}
