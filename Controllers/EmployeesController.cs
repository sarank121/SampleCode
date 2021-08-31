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
        //Get Employee details
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetEmployee()
        {
            return Ok(_employee.GetEmployees());
        }
        //Get Employee details based on ID
        [HttpGet]
        [Route("api/[controller]/{id}")]
        // public ActionResult GetEmployee(Guid id)
        public ActionResult GetEmployee(int id)
        {
            var Employee = _employee.GetEmployee(id);
            if (Employee != null)
            {
                return Ok(Employee);
            }
            return NotFound("Emplyee with id :{Id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employee.AddEmployee(employee);
            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.EmployeeId, employee);
            return Ok("Employee Created");
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        //  public IActionResult DeleteEmployee(Guid Id)
        public IActionResult DeleteEmployee(int Id)
        {
            var employee = _employee.GetEmployee(Id);
            if(employee != null)
            {
                _employee.DeleteEmployee(employee);
                return Ok("Employee Deleted Successfully");
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        // public IActionResult EditEmployee(Guid Id,Employee employee)
        public IActionResult EditEmployee(int Id, Employee employee)
        {
            var exemployee = _employee.GetEmployee(Id);
            if (exemployee != null)
            {
                employee.EmployeeId = exemployee.EmployeeId;
                _employee.EditEmployee(employee);
                return Ok("Employee Updated Successfully");
            }
            return NotFound();
        }
    }
    
}
