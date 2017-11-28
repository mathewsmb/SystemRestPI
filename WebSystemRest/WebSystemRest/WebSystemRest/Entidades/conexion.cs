using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebSystemRest.Entidades
{
    public class conexion
    {
        public SqlConnection getcn = new SqlConnection("server=.;database=BD_Belaa; uid= sa;pwd=sql");
    }
}