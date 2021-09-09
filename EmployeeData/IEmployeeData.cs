using Couchbase.Extensions.DependencyInjection;
using SamplePOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePOC.EmployeeData
{
    public interface IEmployeeData 
    {
        Employee GetEmployee(string email);
      //  List<Employee> GetEmployee(string email);
        List<Employee> GetAllEmployees();
        string AddEmployee(Employee employee);
        string EditEmployee(string email, string firstName);
       // string AddEmployeeDoc(Employee employee);
        string DeleteEmployee(string email);
    }
}
