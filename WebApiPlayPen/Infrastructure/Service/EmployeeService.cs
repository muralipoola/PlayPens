using System.Collections.Generic;
using System.Linq;
using WebApiPlayPen.Model;

namespace Service
{
    public class EmployeeService
    {
        public IEnumerable<Employee> Get()
        {
            using (var ctx = new NorthwindContext())
            {
                return ctx.Employees.ToList();
            }
        }

        public Employee Get(int employeeId)
        {
            using (var ctx = new NorthwindContext())
            {
                return ctx.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            }
        }
    }
}
