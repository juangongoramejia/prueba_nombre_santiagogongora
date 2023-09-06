using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using prueba_nombre_santiagogongora.Models;
using prueba_nombre_santiagogongora.Data;

namespace prueba_nombre_santiagogongora.Controllers
{
    public class PacientesAPIController : ApiController
    {

        //HACEMOS LOS LLAMADOS GET Y POST Y PUT
        // GET api/<controller>
        public List<pacientes> Get()
        {
            return PacienteData.Listar();

        }

        public bool Delete(int id)
        {
            return PacienteData.Eliminar(id);
        }

        public bool Put([FromBody] pacientes oPacientes)
        {
            return PacienteData.Modificar(oPacientes);
        }

    }
}
