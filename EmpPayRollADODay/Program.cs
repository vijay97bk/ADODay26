using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmpPayRollADODay26
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo Repo = new EmployeeRepo();
            Repo.GetAllEmployee();

            Employee employee = new Employee();
            employee.id = 10;
            employee.name = "Vijay";
            employee.basic_pay = 22500;
            employee.gender = 'M';
            employee.phone = 9900422544;
            employee.address = "Kalaburagi";
            employee.department = "IT";
            employee.deduction = 1000;
            employee.taxable_Pay = 500;
            employee.income_tax = 500;
            employee.net_pay = 24500;
            

            Repo.AddEmployee(employee);

         
        }
    }
}
