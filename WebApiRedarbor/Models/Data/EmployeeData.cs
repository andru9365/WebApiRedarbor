using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace WebApiRedarbor.Models.Data
{
    public class EmployeeData
    {
        public static string CreateEmployee(Employee employee)
        {
            bool isValid = false;

            using (SqlConnection sqlConexion = new SqlConnection(Conexion.conexionString))
            {
                try
                {
                    Utilities.EmployeeValidation employeeValidation = new Utilities.EmployeeValidation();

                    isValid = employeeValidation.employeeFieldValidation(employee);
                    if (isValid)
                    {
                        SqlCommand sqlCommand = new SqlCommand("CREATE_EMPLOYEE", sqlConexion);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@companyId", employee.CompanyId);
                        sqlCommand.Parameters.AddWithValue("@createdOn", employee.CreatedOn);
                        sqlCommand.Parameters.AddWithValue("@deletedOn", employee.DeletedOn);
                        sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                        sqlCommand.Parameters.AddWithValue("@fax", employee.Fax);
                        sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                        sqlCommand.Parameters.AddWithValue("@lastLogin", employee.Lastlogin);
                        sqlCommand.Parameters.AddWithValue("@password", employee.Password);
                        sqlCommand.Parameters.AddWithValue("@portalId", employee.PortalId);
                        sqlCommand.Parameters.AddWithValue("@roleId", employee.RoleId);
                        sqlCommand.Parameters.AddWithValue("@statusId", employee.StatusId);
                        sqlCommand.Parameters.AddWithValue("@telephone", employee.Telephone);
                        sqlCommand.Parameters.AddWithValue("@updateOn", employee.UpdatedOn);
                        sqlCommand.Parameters.AddWithValue("@userName", employee.Username);

                        sqlConexion.Open();
                        sqlCommand.ExecuteNonQuery();

                        return "Employee created successfully";
                    }
                    else
                    {
                        return "Required Fields";
                    }
                    
                }
                catch (Exception ex)
                {
                    return "Error created employee, detail in log: " + ex.Message.ToString();
                }

            }

        }

        public static string UpdateEmployee(Employee employee)
        {
            bool isValid = false;

            using (SqlConnection sqlConexion = new SqlConnection(Conexion.conexionString))
            {
                try
                {
                    Utilities.EmployeeValidation employeeValidation = new Utilities.EmployeeValidation();

                    isValid = employeeValidation.employeeFieldValidation(employee);
                    if (isValid)
                    {
                        SqlCommand sqlCommand = new SqlCommand("UPDATE_EMPLOYEE", sqlConexion);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                        sqlCommand.Parameters.AddWithValue("@companyId", employee.CompanyId);
                        sqlCommand.Parameters.AddWithValue("@createdOn", employee.CreatedOn);
                        sqlCommand.Parameters.AddWithValue("@deletedOn", employee.DeletedOn);
                        sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                        sqlCommand.Parameters.AddWithValue("@fax", employee.Fax);
                        sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                        sqlCommand.Parameters.AddWithValue("@lastLogin", employee.Lastlogin);
                        sqlCommand.Parameters.AddWithValue("@password", employee.Password);
                        sqlCommand.Parameters.AddWithValue("@portalId", employee.PortalId);
                        sqlCommand.Parameters.AddWithValue("@roleId", employee.RoleId);
                        sqlCommand.Parameters.AddWithValue("@statusId", employee.StatusId);
                        sqlCommand.Parameters.AddWithValue("@telephone", employee.Telephone);
                        sqlCommand.Parameters.AddWithValue("@updateOn", employee.UpdatedOn);
                        sqlCommand.Parameters.AddWithValue("@userName", employee.Username);
                    
                        sqlConexion.Open();
                        sqlCommand.ExecuteNonQuery();
                        return "Employee updated successfully";
                    }
                    else
                    {
                        return "Required Fields";
                    }
                }
                catch (Exception ex)
                {
                    return "Error updating employee, detail in log: " + ex.Message.ToString();
                }
            }
        }

        public static List<Employee> GetEmployee()
        {
            List<Employee> lstEmployees = new List<Employee>();
            using (SqlConnection sqlConexion = new SqlConnection(Conexion.conexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GET_EMPLOYEE", sqlConexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    sqlConexion.Open();
                    sqlCommand.ExecuteNonQuery();

                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lstEmployees.Add(new Employee()
                            {
                                EmployeeId = Convert.ToInt32(dr["employeeId"]),
                                CompanyId = Convert.ToInt32(dr["companyId"]),
                                CreatedOn = Convert.ToDateTime(dr["createdOn"].ToString()),
                                DeletedOn = Convert.ToDateTime(dr["deletedOn"].ToString()),
                                Email = dr["email"].ToString(),
                                Fax = dr["fax"].ToString(),
                                Name = dr["name"].ToString(),
                                Lastlogin = Convert.ToDateTime(dr["lastLogin"].ToString()),
                                Password = dr["password"].ToString(),
                                PortalId = Convert.ToInt32(dr["portalId"]),
                                RoleId = Convert.ToInt32(dr["roleId"]),
                                StatusId = Convert.ToInt32(dr["statusId"]),
                                Telephone = dr["telephone"].ToString(),
                                UpdatedOn = Convert.ToDateTime(dr["updateOn"].ToString()),
                                Username = dr["userName"].ToString(),

                            });
                        }

                    }



                    return lstEmployees;
                }
                catch (Exception ex)
                {
                    return lstEmployees;
                }
            }
        }

        public static Employee GetEmployeeById(int idEmployee)
        {
            Employee employee = new Employee();
            using (SqlConnection sqlConexion = new SqlConnection(Conexion.conexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GET_EMPLOYEE_BY_ID", sqlConexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@employeeId", idEmployee);

                try
                {
                    sqlConexion.Open();
                    sqlCommand.ExecuteNonQuery();

                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            employee = new Employee()
                            {
                                EmployeeId = Convert.ToInt32(dr["employeeId"]),
                                CompanyId = Convert.ToInt32(dr["companyId"]),
                                CreatedOn = Convert.ToDateTime(dr["createdOn"].ToString()),
                                DeletedOn = Convert.ToDateTime(dr["deletedOn"].ToString()),
                                Email = dr["email"].ToString(),
                                Fax = dr["fax"].ToString(),
                                Name = dr["name"].ToString(),
                                Lastlogin = Convert.ToDateTime(dr["lastLogin"].ToString()),
                                Password = dr["password"].ToString(),
                                PortalId = Convert.ToInt32(dr["portalId"]),
                                RoleId = Convert.ToInt32(dr["roleId"]),
                                StatusId = Convert.ToInt32(dr["statusId"]),
                                Telephone = dr["telephone"].ToString(),
                                UpdatedOn = Convert.ToDateTime(dr["updateOn"].ToString()),
                                Username = dr["userName"].ToString(),
                            };
                        }

                    }

                    return employee;
                }
                catch (Exception ex)
                {
                    return employee;
                }
            }
        }

        public static string DeleteEmployee(int idEmployee)
        {
            using (SqlConnection sqlConexion = new SqlConnection(Conexion.conexionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("DELETE_EMPLOYEE", sqlConexion);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@employeeId", idEmployee);

                    sqlConexion.Open();
                    sqlCommand.ExecuteNonQuery();
                    return "Employee removed successfully";
                }
                catch (Exception ex)
                {
                    return "Error deleting employee, detail in log: " + ex.Message.ToString();
                }
            }
        }

    }
}