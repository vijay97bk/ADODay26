using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EmpPayRollADODay26
{
    public class EmployeeRepo
    {
        /// <summary>
        /// The connection string UC1
        /// </summary>
        public static string ConnectionString = "Server=DESKTOP-ERQSHRG;Initial Catalog=Payroll_Service;Integrated Security=SSPI;";
        SqlConnection connection = new SqlConnection(ConnectionString);
        List<Employee> employees = new List<Employee>();
        /// <summary>
        /// Gets all employee. UC2
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployee()
        {

            Employee employeeModel = new Employee();
            using (connection)
            {
                string query = @"SELECT id,name,start,gender,phone,address,department,basicPay,deduction,taxable_Pay,income_tax,net_pay,company
                                FROM employee_payroll;";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeeModel.id = dr.GetInt32(0);
                        employeeModel.name = dr.GetString(1);
                        employeeModel.start = dr.GetDateTime(2);
                        employeeModel.gender = Convert.ToChar(dr.GetString(3));
                        employeeModel.phone = dr.GetInt32(4);
                        employeeModel.address = dr.GetString(5);
                        employeeModel.department = dr.GetString(6);
                        employeeModel.basic_pay = dr.GetInt32(7);
                        employeeModel.deduction = dr.GetInt32(5);
                        employeeModel.taxable_Pay = dr.GetInt32(5);
                        employeeModel.income_tax = dr.GetInt32(5);
                        employeeModel.net_pay = dr.GetInt32(5);
                        employeeModel.company = dr.GetString(5);
                        employees.Add(employeeModel);
                        Console.WriteLine(employeeModel.id + "," + employeeModel.name + "," + employeeModel.start);
                    }
                }
                connection.Close();
            }
            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", employee.id);
                command.Parameters.AddWithValue("@name", employee.name);
                command.Parameters.AddWithValue("@basic_pay", employee.basic_pay);
                command.Parameters.AddWithValue("@gender", employee.gender);
                command.Parameters.AddWithValue("@phone", employee.phone);
                command.Parameters.AddWithValue("@address", employee.address);
                command.Parameters.AddWithValue("@department", employee.department);
                command.Parameters.AddWithValue("@deduction", employee.deduction);
                command.Parameters.AddWithValue("@taxable_pay", employee.taxable_Pay);
                command.Parameters.AddWithValue("@income_tax", employee.income_tax);
                command.Parameters.AddWithValue("@net_pay", employee.net_pay);
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
        /// <summary>
        /// Updates the record. UC3
        /// </summary>
        public void UpdateRecord()
        {
            string query = @"update employee_payroll set basic_pay=3000000 where name='Terisa';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Retrives the data from range. UC5
        /// </summary>
        /// <param name="range1">The range1.</param>
        /// <param name="range2">The range2.</param>
        public void RetriveDataFromRange()
        {
            string query = @"select * from employee_payroll where start between '2002-01-01' and  GETDATE();";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Operations()
        {
            string query = @"select sum(salary) from employee_payroll where gender='f';
                             select avg(salary) from employee_payroll where gender='f';
                             select min(salary) from employee_payroll where gender='f';
                             select max(salary) from employee_payroll where gender='f';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}