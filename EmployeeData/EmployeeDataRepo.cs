using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SamplePOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePOC.EmployeeData
{
    public class EmployeeDataRepo : IEmployeeData
    {
        public readonly IBucket _bucket;
       
        public EmployeeDataRepo(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("Test");
        }

       

        public string AddEmployee(Employee employee)
        {
            var key = Guid.NewGuid().ToString();
            _bucket.Insert(key, employee);
            var jsondata = JsonConvert.SerializeObject(employee);
            return "Inserted document: " + jsondata;
        }
        public string DeleteEmployee(string email)
        {
            var n1ql = "Delete FROM Test d WHERE d.email = $email";
            var query = QueryRequest.Create(n1ql);
            query.AddNamedParameter("$email", email);
            _bucket.Query<Employee>(query);
            var getEmployee = GetAllEmployees();
            var jsondata = JsonConvert.SerializeObject(getEmployee);
            return "Deleted Successfully: " + jsondata;
        }

        public string EditEmployee(string email, string firstName)
        {
            
            var n1ql = "Update Test set firstName =$name where email = $email";
            var query = QueryRequest.Create(n1ql);
            query.AddNamedParameter("$email", email);
            query.AddNamedParameter("$name", firstName);
            _bucket.Query<Employee>(query);
            var getEmployee = GetAllEmployees();
            var jsondata = JsonConvert.SerializeObject(getEmployee);
            return "Updated Successfully" + jsondata;
        }
        
        public List<Employee> GetEmployee(string email)
        {
            var n1ql = "SELECT d.* FROM Test d WHERE d.email = $email";
            var query = QueryRequest.Create(n1ql);
            query.AddNamedParameter("$email", email);
            var result = _bucket.Query<Employee>(query);
            return result.Rows;
        }
        public List<Employee> GetAllEmployees()
        {
            var n1ql = "SELECT d.* FROM Test d";
            var query = QueryRequest.Create(n1ql);
            var result = _bucket.Query<Employee>(query);
            return result.ToList();
        }
    }
   
}
