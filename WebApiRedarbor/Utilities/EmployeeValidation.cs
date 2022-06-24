using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRedarbor.Models;

namespace WebApiRedarbor.Utilities
{
    public class EmployeeValidation
    {
        public bool employeeFieldValidation(Employee employee)
        {
            bool isValid = false;

            if (employee.CompanyId == 0 || string.IsNullOrWhiteSpace(employee.CreatedOn.ToString()) ||
                string.IsNullOrWhiteSpace(employee.DeletedOn.ToString()) || string.IsNullOrWhiteSpace(employee.Email) ||
                string.IsNullOrWhiteSpace(employee.Fax) || string.IsNullOrWhiteSpace(employee.Name) ||
                string.IsNullOrWhiteSpace(employee.Lastlogin.ToString()) || string.IsNullOrWhiteSpace(employee.Password) ||
                employee.PortalId == 0 || employee.RoleId == 0 ||
                employee.StatusId == 0 || string.IsNullOrWhiteSpace(employee.Telephone) ||
                string.IsNullOrWhiteSpace(employee.UpdatedOn.ToString()) || string.IsNullOrWhiteSpace(employee.Username)
                )
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;

        }
    }
}