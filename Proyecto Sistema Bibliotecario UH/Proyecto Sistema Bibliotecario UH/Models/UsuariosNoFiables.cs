using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Bibliotecario_UH.Models
{
    public class UsuariosNoFiables
    {
        public string nombreUsuarioNoFiable { get; set; }
        public string nombreLibroNoFiable { get; set; }
        public int cantidadLibroNoFiable { get; set; }
        public DataTable tabla { get; set; }

        public UsuariosNoFiables()
        {
            nombreUsuarioNoFiable = "";
            nombreLibroNoFiable = "";
            cantidadLibroNoFiable = 0;
            tabla = new DataTable();
        }
    }
}