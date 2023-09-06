using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prueba_nombre_santiagogongora.Models
{
    public class pacientes
    {
        //Creamos el modelo de la tabla "pacientes"
        public int id { get; set; }

        //hacemos los campos obligatorios desde el modelo
        [Required(ErrorMessage = "{0} es requerido")]
        public string Número_documento { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public string Telefono { get; set;}
        [Required(ErrorMessage = "{0} es requerido")]
        public string Correo { get; set;}
        public DateTime Fecha_nacimiento { get; set;}

        [Required(ErrorMessage = "{0} es requerido SOLO SE PERMITE 1 o 0")]
        public int Estado_afiliacion { get; set; }


    }
}