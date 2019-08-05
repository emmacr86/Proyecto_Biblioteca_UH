using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Bibliotecario_UH.Models
{
    public class Usuario
    {
        public int cedulaUsuario { get; set; }

        public string contrasenaUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string apellidosUsuario { get; set; }

        public string direccionUsuario { get; set; }

        public string tipoUsuario { get; set; }

        public DataTable tabla { get; set; }

        public Usuario()
        {
            cedulaUsuario = 0;
            contrasenaUsuario = "";
            nombreUsuario = "";
            apellidosUsuario = "";
            direccionUsuario = "";
            tipoUsuario = "";
            tabla = new DataTable();
        }
    }
}