using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiRedarbor.Models;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace UnitTestRedarbor
{
    [TestClass]
    public class UnitTestRedarbor
    {
            Uri uriBaseAddress = new Uri(ConfigurationManager.AppSettings["endPointApiRedarbor"]);
            HttpClient httpClient;

            public UnitTestRedarbor()
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = uriBaseAddress;
            }

        [TestMethod]
        public void CreateEmployee()
        {
            Employee employee = new Employee();

            employee.CompanyId = 1;
            employee.CreatedOn = Convert.ToDateTime("2000-01-01 00:00:00");
            employee.DeletedOn = Convert.ToDateTime("2000-01-01 00:00:00");
            employee.Email = "test1@test.test.tmp";
            employee.Fax = "000.000.000";
            employee.Name = "test1";
            employee.Lastlogin = Convert.ToDateTime("2000-01-01 00:00:00");
            employee.Password = "test";
            employee.PortalId = 1;
            employee.RoleId = 1;
            employee.StatusId = 1;
            employee.Telephone = "000.000.000";
            employee.UpdatedOn = Convert.ToDateTime("2000-01-01 00:00:00");
            employee.Username = "test1";

            string jsonRequest = JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(httpClient.BaseAddress + "/Redarbor", stringContent).Result;

            Assert.IsTrue(httpResponseMessage.IsSuccessStatusCode);
        }

        [TestMethod]
        public void GetEmployee()
        {
            Employee employee = new Employee();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(httpClient.BaseAddress + "/Redarbor").Result;

            Assert.IsTrue(httpResponseMessage.IsSuccessStatusCode);
        }

        [TestMethod]
        public void GetEmployeeById()
        {
            Employee employee = new Employee();
            employee.EmployeeId = 2;
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(httpClient.BaseAddress + "/Redarbor/" + employee.EmployeeId).Result;

            Assert.IsTrue(httpResponseMessage.IsSuccessStatusCode);
        }

        [TestMethod]
        public void UpdateEmployee()
        {
            Employee employee = new Employee();

            employee.EmployeeId = 1;
            employee.CompanyId = 2;
            employee.CreatedOn = Convert.ToDateTime("2022-06-24 00:00:00");
            employee.DeletedOn = Convert.ToDateTime("2022-06-24 00:00:00");
            employee.Email = "test1@test.test.tmp";
            employee.Fax = "312.558.0538";
            employee.Name = "Andrés";
            employee.Lastlogin = Convert.ToDateTime("2022-06-24 00:00:00");
            employee.Password = "12345";
            employee.PortalId = 1;
            employee.RoleId = 1;
            employee.StatusId = 1;
            employee.Telephone = "811.57.57";
            employee.UpdatedOn = Convert.ToDateTime("2022-06-24 00:00:00");
            employee.Username = "andres9365";

            string jsonRequest = JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync(httpClient.BaseAddress + "/Redarbor", stringContent).Result;

            Assert.IsTrue(httpResponseMessage.IsSuccessStatusCode);
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            Employee employee = new Employee();
            employee.EmployeeId = 1;
            HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync(httpClient.BaseAddress + "/Redarbor/"+ employee.EmployeeId).Result;

            Assert.IsTrue(httpResponseMessage.IsSuccessStatusCode);
        }

    }
}

