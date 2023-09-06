using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba_nombre_santiagogongora.Models;

namespace prueba_nombre_santiagogongora.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes


        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
        private static List<pacientes> oLista = new List<pacientes>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar() 
        {
       
            return View();
        }

        //GENERAMOS LA LOGICA PARA INSERTAR LOS REGISTROS
        [HttpPost]
        public ActionResult Registrar(pacientes oPacientes)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                //llamamos el procedimiento almacenado sp_registrar
                SqlCommand cmd = new SqlCommand("sp_Registrar", oconexion);
                cmd.Parameters.AddWithValue("Número_documento", oPacientes.Número_documento);
                cmd.Parameters.AddWithValue("Nombres", oPacientes.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", oPacientes.Apellidos);
                cmd.Parameters.AddWithValue("Correo", oPacientes.Correo);
                cmd.Parameters.AddWithValue("Telefono", oPacientes.Telefono);
                cmd.Parameters.AddWithValue("Fecha_nacimiento", DateTime.Now);
                cmd.Parameters.AddWithValue("Estado_afiliacion", oPacientes.Estado_afiliacion);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                //ejecutamos el query con los parametros indicados
                cmd.ExecuteNonQuery();

            }

            return RedirectToAction("Index", "Pacientes");

        }

    }
}