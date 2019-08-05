using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Bibliotecario_UH.Models
{
    public class Prestamos
    {
        public int codigoPrestamo { get; set; }
        public string nombreSocioPrestamo { get; set; }
        public string nombreLibroPrestamo { get; set; }
        public int cantidadSolicitadaLibroPrestamo { get; set; }
        public string fechaPrestamo { get; set; }
        public DataTable tabla { get; set; }

        public Prestamos()
        {
            codigoPrestamo = 0;
            nombreSocioPrestamo = "";
            nombreLibroPrestamo = "";
            cantidadSolicitadaLibroPrestamo = 0;
            fechaPrestamo = "";
            tabla = new DataTable();
        }
    }
}