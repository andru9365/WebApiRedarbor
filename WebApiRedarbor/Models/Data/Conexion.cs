using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApiRedarbor.Models.Data
{
    public class Conexion
    {
        public static string conexionString = ConfigurationManager.AppSettings["connDB"];
    }
}