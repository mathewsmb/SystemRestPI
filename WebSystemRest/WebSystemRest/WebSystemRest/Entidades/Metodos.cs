using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystemRest.Models;
using System.Data;
using System.Data.SqlClient;


namespace WebSystemRest.Entidades
{
    public class Metodos
    {
        conexion cn = new conexion();
        BD_BelaaEntities bd = new BD_BelaaEntities();
        tb_PlatoxTipo pt = new tb_PlatoxTipo();

        public List<tb_PlatoxTipo> ListarPlatos()
        {
            List<tb_PlatoxTipo> lista = new List<tb_PlatoxTipo>();
            SqlCommand cmd = new SqlCommand("select p.nom_plato, t.desc_tipo from tb_plato p join tb_tipo t on p.id_tipo = t.id_tipo", cn.getcn);
            cn.getcn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_PlatoxTipo pt = new tb_PlatoxTipo();
                pt.nom_plato = dr["nom_plato"].ToString();
                pt.desc_tipo = dr["desc_tipo"].ToString();
                
                lista.Add(pt);
            }
            cn.getcn.Close();
            return lista;
        }

        public List<tb_menu> ListarMenu()
        {
            List<tb_menu> lista = new List<tb_menu>();
            SqlCommand cmd = new SqlCommand("select * from tb_menu", cn.getcn);
            cn.getcn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_menu reg = new tb_menu();
                reg.id_menu = int.Parse(dr["id_menu"].ToString());
                reg.cant_menu = int.Parse(dr["cant_menu"].ToString());
                reg.fec_menu = dr["fec_menu"].ToString();
                reg.tiempoTotal_menu = dr["tiempoTotal_menu"].ToString();

                lista.Add(reg);
            }
            cn.getcn.Close();
            return lista;
        }

        public string RegistrarPlato(tb_plato reg)
        {
            string msg = "";
            cn.getcn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tb_plato(nom_plato,id_tipo) values(@nomplato, @idtipo)", cn.getcn);
                cmd.Parameters.AddWithValue("@nomplato", reg.nom_plato);
                cmd.Parameters.AddWithValue("@idtipo", reg.id_tipo);
                cmd.ExecuteNonQuery();
                msg = "Se agrego el plato";
            }
            catch (Exception e) { msg = "Error al registrar Plato" + e.Message; }
            finally { cn.getcn.Close(); }
            return msg;
        }

        public List<tb_tipo> ListaTipoMenu()
        {
            cn.getcn.Open();
            List<tb_tipo> lista = new List<tb_tipo>();
            SqlCommand cmd = new SqlCommand("select * from tb_tipo", cn.getcn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_tipo reg = new tb_tipo();
                reg.id_tipo = int.Parse(dr["id_tipo"].ToString());
                reg.desc_tipo = dr["desc_tipo"].ToString();
                lista.Add(reg);
            }
            cn.getcn.Close();
            return lista;
        } 

        public List<tb_ingredientes> ListaIngredientes()
        {
            cn.getcn.Open();
            List<tb_ingredientes> lista = new List<tb_ingredientes>();
            SqlCommand cmd = new SqlCommand("select * from tb_ingredientes", cn.getcn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_ingredientes reg = new tb_ingredientes();
                reg.id_ing = int.Parse(dr["id_ing"].ToString());
                reg.desc_ing = dr["desc_ing"].ToString();
                reg.stock_ing = int.Parse(dr["stock_ing"].ToString());
                reg.costo_ing = decimal.Parse(dr["costo_ing"].ToString()); 
                reg.id_med = int.Parse(dr["id_med"].ToString());

                lista.Add(reg);
            }
            cn.getcn.Close();
            return lista;
        }
    }
}