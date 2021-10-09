using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormularoPrueba.Models
{
    public class ModeloTipoDocGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String nombre;

        [Required]
        [MinLength(3)]
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}