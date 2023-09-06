using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using prueba_nombre_santiagogongora.Models;
using System.Configuration;

namespace prueba_nombre_santiagogongora.Data
{
    public class PacienteData
    {

        //DECLARAMOS LA CONEXION
        private static string Conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        //EMPEZAMOS HACER EL METODO PARA OBTENER LOS REGISTROS
        public static List<pacientes> Listar()
        {
            List<pacientes> oListaPacientes = new List<pacientes>();
            using (SqlConnection oConexion = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPacientes.Add(new pacientes()
                            {

                                id = Convert.ToInt32(dr["id"]),
                                Número_documento = dr["Número_documento"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),

                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),

                                Fecha_nacimiento = Convert.ToDateTime(dr["Fecha_nacimiento"].ToString()),
                                Estado_afiliacion = Convert.ToInt32(dr["Estado_afiliacion"].ToString())

                            });

                        }
                    }

                    return oListaPacientes;

                }
                catch (Exception ex)
                {
                    return oListaPacientes;
                }

            }



        }

        //AGREGAMOS LA LOGICA PARA ELIMINAR REGISTROS POR ID
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

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


        //AGREGAMOS LA LOGICA PARA MODIFICAR REGISTROS

        public static bool Modificar(pacientes oPacientes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Editar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oPacientes.id);
                cmd.Parameters.AddWithValue("@Número_documento", oPacientes.Número_documento);
                cmd.Parameters.AddWithValue("@Nombres", oPacientes.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", oPacientes.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", oPacientes.Correo);
                cmd.Parameters.AddWithValue("@Telefono", oPacientes.Telefono);
                cmd.Parameters.AddWithValue("@Fecha_nacimiento", oPacientes.Fecha_nacimiento);
                cmd.Parameters.AddWithValue("@Estado_afiliacion", oPacientes.Estado_afiliacion);

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