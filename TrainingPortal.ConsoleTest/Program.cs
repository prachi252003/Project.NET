using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //add employee
            /*EmployeeRepository repo =
new EmployeeRepository();

            try
            {
                Employee emp = new Employee()
                {
                    Name = "Soha",
                    Designation = "Developer",
                    Email = "soha@gmail.com",
                    Phone = "9876543210"
                };

                bool result = repo.AddEmployee(emp);

                Console.WriteLine(result
                ? "Employee Added"
                : "Employee Not Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            //getallemployees
            /*EmployeeRepository repo =
new EmployeeRepository();

            try
            {
                List<Employee> employees =
                repo.GetAllEmployees();

                foreach (Employee emp in employees)
                {
                    Console.WriteLine(
                    $"{emp.EmpId} {emp.Name} {emp.Designation}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            //getemployeebyid
            /*EmployeeRepository repo =
new EmployeeRepository();

            try
            {
                Employee emp =
                repo.GetEmployeeById(1001);

                Console.WriteLine(emp.Name);
                Console.WriteLine(emp.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            //updateemployee
            /*EmployeeRepository repo =
new EmployeeRepository();

            try
            {
                Employee emp =
                repo.GetEmployeeById(1001);

                emp.Designation =
                "Senior Developer";

                bool result =
                repo.UpdateEmployee(emp);

                Console.WriteLine(result
                ? "Updated"
                : "Failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            //deleteemployee
            EmployeeRepository repo =
new EmployeeRepository();

            try
            {
                bool result =
                repo.DeleteEmployee(1004);

                Console.WriteLine(result
                ? "Deleted"
                : "Failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
