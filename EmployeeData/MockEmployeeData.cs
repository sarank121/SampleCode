using SamplePOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePOC.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
              //  EmployeeId=Guid.NewGuid(),
              EmployeeId=1,
                Name ="Employee1"
            },
              new Employee()
            {
               // EmployeeId=Guid.NewGuid(),
               EmployeeId=2,
                Name ="Employee2"
            },
        };
        public Employee AddEmployee(Employee employee)
        {
            // employee.EmployeeId = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var exEmployee = GetEmployee(employee.EmployeeId);
            exEmployee.Name = employee.Name;
            return employee;
        }

        //   public Employee GetEmployee(Guid Id)
        public Employee GetEmployee(int Id)
        {
            return employees.SingleOrDefault(x => x.EmployeeId ==Id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
