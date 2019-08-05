using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Bibliotecario_UH.Models
{
    public class Libros
    {
        public int codigoLibro { get; set; }

        public string tituloLibro { get; set; }

        public string autorLibro { get; set; }

        public int cantidadLibro { get; set; }

        public string ubicacionLibro { get; set; }

        public string asignaturaLibro { get; set; }

        public DataTable tabla { get; set; }

        public Libros()
        {
            codigoLibro = 0; 
            tituloLibro = "";
            autorLibro = "";
            cantidadLibro = 0;
            ubicacionLibro = "";
            asignaturaLibro = ""; 
            tabla = new DataTable();
        }
    }
}