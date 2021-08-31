using SamplePOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePOC.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();
        //Employee GetEmployee(Guid Id);
        Employee GetEmployee(int Id);
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
    }
}
