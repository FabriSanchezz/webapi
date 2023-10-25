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
    public class PersonaData
    {

        public static bool Registrar(Persona oPersona)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_cp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", oPersona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", oPersona.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", oPersona.Direccion);
                cmd.Parameters.AddWithValue("@Email", oPersona.Email);
                cmd.Parameters.AddWithValue("@Celular", oPersona.Celular);
                cmd.Parameters.AddWithValue("@Edad", oPersona.Edad);
                cmd.Parameters.AddWithValue("@ID_Ciudad", oPersona.ID_Ciudad);

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
        public static bool Modificar(Persona oPersona)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", oPersona.ID);
                cmd.Parameters.AddWithValue("@Nombre", oPersona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", oPersona.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", oPersona.Direccion);
                cmd.Parameters.AddWithValue("@Email", oPersona.Email);
                cmd.Parameters.AddWithValue("@Celular", oPersona.Celular);
                cmd.Parameters.AddWithValue("@Edad", oPersona.Edad);

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


        public static List<Persona> Listar()
        {
            List<Persona> oListaUsuario = new List<Persona>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Persona()
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Email = dr["Email"].ToString(),
                                Celular = dr["Celular"].ToString(),
                                Edad = dr["Edad"].ToString(),
                                ID_Ciudad = dr["ID_Ciudad"].ToString(),
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

        public static Persona Obtener(int ID)
        {
            Persona oPersona = new Persona();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_obtener", oConexion);
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
                            oPersona = new Persona()
                            {

                                ID = Convert.ToInt32(dr["ID"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Email = dr["Email"].ToString(),
                                Celular = dr["Celular"].ToString(),
                                Edad = dr["Edad"].ToString(),
                                ID_Ciudad = dr["ID_Ciudad"].ToString(),
                            };
                        }

                    }



                    return oPersona;
                }
                catch (Exception ex)
                {
                    return oPersona;
                }
            }
        }
        public static bool Eliminar(int ID)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cp_eliminar", oConexion);
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