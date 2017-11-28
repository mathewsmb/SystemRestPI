using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebSystemRest.Entidades
{
    public static class Logueo
    {
        public static bool Autenticar(string usuario, string clave)
        {
            //consulta a la base de datos
            string sql = @"SELECT COUNT(*)
                          FROM logueo
                          WHERE usuario = @user AND clave = @pass";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection("server=.;database=BD_SRESBE; uid= sa;pwd=sql"))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@user", usuario); //enviamos los parametros
                cmd.Parameters.AddWithValue("@pass", clave);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count == 0)
                    return false;
                else
                    return true;

            }
        }
    }
}