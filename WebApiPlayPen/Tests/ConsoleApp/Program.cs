using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using WebApiPlayPen.Model;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var service = new EmployeeService();
            var emps = service.Get();
            Console.ReadLine();
        }
    }
}
