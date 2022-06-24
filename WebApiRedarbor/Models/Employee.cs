using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiRedarbor.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime DeletedOn { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Fax { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Lastlogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int PortalId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Username { get; set; }

    }
}