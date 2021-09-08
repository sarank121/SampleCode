using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SamplePOC.EmployeeData;
using SamplePOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePOC.Controllers
{
    [ApiController]
    
    public class EmployeesController : ControllerBase
    {
        public IEmployeeData _employee;
        public EmployeesController(IEmployeeData employee)
        {
            _employee = employee;
        }
       
        /// <summary>
        /// Get Employee details with email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/{email}")]
        public ActionResult GetEmployee(string email)
        {
            var Employee = _employee.GetEmployee(email);
            if (Employee != null)
            {
                return Ok(Employee);
            }
            return NotFound();
          //  return Ok(_employee.GetEmployee(email));
        }
        /// <summary>
        /// Get all Employee Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetEmployee()
        {
            var Employee = _employee.GetAllEmployees();
            if (Employee != null)
            {
                return Ok(Employee);
            }
            return NotFound();
        }
        /// <summary>
        /// Post Employee Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            var status =_employee.AddEmployee(employee);
            return Ok(status);
        }

        [HttpDelete]
        [Route("api/[controller]/{email}")]
        //  public IActionResult DeleteEmployee(Guid Id)
        public IActionResult DeleteEmployee(string email)
        {
            var employee = _employee.DeleteEmployee(email);
            return Ok(employee);
        }
        [HttpPatch]
        [Route("api/[controller]/{email}")]
        // public IActionResult EditEmployee(Guid Id,Employee employee)
        public IActionResult EditEmployee(string email, string firstName)
        {
            var status = _employee.EditEmployee(email, firstName);
            return Ok(status);
        }
    }
    
}
