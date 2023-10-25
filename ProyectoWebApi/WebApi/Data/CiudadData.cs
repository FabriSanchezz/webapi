using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Data
{
    public class CiudadData
    {

        public static bool Registrar(Ciudadd oCiudadd)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_cp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", oCiudadd.ID);
                cmd.Parameters.AddWithValue("@Ciudad", oCiudadd.Ciudad);
                

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }



            }
        }
        //modificar
        public static bool Modificar(Ciudadd oCiudadd)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_editcity", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", oCiudadd.ID);
                cmd.Parameters.AddWithValue("@Ciudad", oCiudadd.Ciudad);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static List<Ciudadd> Listar()
        {
            List<Ciudadd> oListaUsuario = new List<Ciudadd>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_listarcity", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Ciudadd()
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                Ciudad = dr["Ciuadad"].ToString(),
                                
                            });
                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Ciudadd Obtener(int ID)
        {
            Ciudadd oCiudadd = new Ciudadd();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_obtenercity", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oCiudadd = new Ciudadd()
                            {

                                ID = Convert.ToInt32(dr["ID"]),
                                Ciudad = dr["Ciudad"].ToString(),
                                
                            };
                        }

                    }



                    return oCiudadd;
                }
                catch (Exception ex)
                {
                    return oCiudadd;
                }
            }
        }
        public static bool Eliminar(int ID)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_eliminarcity", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}