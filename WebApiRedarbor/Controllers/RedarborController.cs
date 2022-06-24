using System.Collections.Generic;
using System.Web.Http;
using WebApiRedarbor.Models;
using WebApiRedarbor.Models.Data;

namespace WebApiRedarbor.Controllers
{
    public class RedarborController : ApiController
    {
        public List<Employee> Get()
        {
            return EmployeeData.GetEmployee();
        }

        public Employee Get(int id)
        {
            return EmployeeData.GetEmployeeById(id);
        }

        public string Post([FromBody]Employee oEmployee)
        {
            return EmployeeData.CreateEmployee(oEmployee);
        }

        public string Put([FromBody]Employee oEmployee)
        {
            return EmployeeData.UpdateEmployee(oEmployee);
        }

        public string Delete(int id)
        {
            return EmployeeData.DeleteEmployee(id);
        }
    }
}