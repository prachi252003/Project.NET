using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int empId);
        bool AddEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int empId);
    }
}
