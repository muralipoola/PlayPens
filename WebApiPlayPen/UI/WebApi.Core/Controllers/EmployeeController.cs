using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;
using WebApiPlayPen.Model;

namespace WebApi.Core.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly EmployeeService _service = new EmployeeService();

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return _service.Get();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
