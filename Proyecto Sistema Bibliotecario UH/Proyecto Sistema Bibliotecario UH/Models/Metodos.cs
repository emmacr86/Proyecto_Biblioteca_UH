using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Bibliotecario_UH.Models
{
    public class Metodos
    {
        //Metodo para validar Usuario
        public DataSet ValidarUsuarioIngresado()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Usuario", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(tabla);
            return tabla;
        }

        //Metodo para Mostrar Libros
        public DataSet MostrarLibros()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Libro WHERE cantidadLibro != 0", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Agregar Usuarios
        public int InsertarUsuario(int cedula, string contrasena, string nombre, string apellidos, string ubicacion, string tipoUsuario)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Insert Into Tabla_Usuario(cedulaUsuario,contrasenaUsuario,nombreUsuario,apellidosUsuario,direccionUsuario,tipoUsuario)Values('"
            + cedula + "','" + contrasena + "','" + nombre + "','" + apellidos + "','" + ubicacion + "','" + tipoUsuario + "')", conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Eliminar Usuario
        public int EliminarUsuario(int cedula)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Delete From Tabla_Usuario Where cedulaUsuario=" + cedula, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Mostrar Socio
        public DataSet MostrarSocio()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Usuario Where tipoUsuario='socio'", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo Moficar Socio
        public int ModificarSocio(int cedula, string contrasena, string nombre, string apellidos, string ubicacion, string tipoUsuario)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Update Tabla_Usuario Set contrasenaUsuario='" + contrasena + "',nombreUsuario='" + nombre + "',apellidosUsuario='" + apellidos + "',direccionUsuario='" + ubicacion + "',tipoUsuario='" + tipoUsuario + "' Where cedulaUsuario=" + cedula, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Filtrar Usuario
        public DataSet FiltrarUsuario(int cedula)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Select * From Tabla_Usuario Where cedulaUsuario=" + cedula, conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Mostrar Usuarios
        public DataSet MostrarUsuarios()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Usuario", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Agregar Libros
        public int InsertarLibro(string tituloLibro, string autorLibro, int cantidadLibro, string ubicacionLibro, string asignaturaLibro)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Insert Into Tabla_Libro(tituloLibro,autorLibro,cantidadLibro,ubicacionLibro,asignaturaLibro)Values('"
            + tituloLibro + "','" + autorLibro + "','" + cantidadLibro + "','" + ubicacionLibro + "','" + asignaturaLibro + "')", conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Eliminar Libros
        public int EliminarLibro(int codigo)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Delete From Tabla_Libro Where codigoLibro=" + codigo, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Mostrar Libros
        public DataSet MostrarLibrosCompletos()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Libro", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Filtrar Libro
        public DataSet FiltrarLibro(int codigo)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Select * From Tabla_Libro Where codigoLibro=" + codigo, conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo Moficar Libro
        public int ModificarLibro(int codigoLibro, string tituloLibro, string autorLibro, int cantidadLibro, string ubicacionLibro, string asignaturaLibro)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Update Tabla_Libro Set tituloLibro='" + tituloLibro + "',autorLibro='" + autorLibro + "',cantidadLibro='" + cantidadLibro + "',ubicacionLibro='" + ubicacionLibro + "',asignaturaLibro='" + asignaturaLibro + "' Where codigoLibro=" + codigoLibro, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Mostrar Prestamos
        public DataSet MostrarPrestamos()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT * FROM Tabla_Prestamos", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Mostrar No Fiables
        public DataSet MostrarNoFiables()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("SELECT nombreSocioPrestamo, nombreLibroPrestamo, SUM(cantidadSolicitadaLibroPrestamo) FROM Tabla_Prestamos WHERE cantidadSolicitadaLibroPrestamo <=10 GROUP BY nombreSocioPrestamo, nombreLibroPrestamo, cantidadSolicitadaLibroPrestamo", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo para Agregar Prestamos
        public int InsertarPrestamo(string nombreSocio, string nombreLibro, int cantidadLibro, string fechaPrestamo)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Insert Into Tabla_Prestamos(nombreSocioPrestamo,nombreLibroPrestamo,cantidadSolicitadaLibroPrestamo,fechaPrestamo)Values('"
            + nombreSocio + "','" + nombreLibro + "','" + cantidadLibro + "','" + fechaPrestamo + "')", conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Eliminar Prestamos
        public int EliminarPrestamo(int codigo)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Delete From Tabla_Prestamos Where codigoPrestamo=" + codigo, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        //Metodo para Filtrar Prestamo
        public DataSet FiltrarPrestamo(int codigo)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Select * From Tabla_Prestamos Where codigoPrestamo=" + codigo, conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        //Metodo Moficar Libro
        public int ModificarPrestamo(int codigoPrestamo, string nombreUsuario, string nombreLibro, int cantidadLibro, string Fecha)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=proyecto-bibliotecario-uh.database.windows.net;Initial Catalog=Sistema_Bibliotecario_UH;Integrated Security=False;User ID=Emma;Password=Felicidad123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand comando = new SqlCommand("Update Tabla_Prestamos Set nombreSocioPrestamo='" + nombreUsuario + "',nombreLibroPrestamo='" + nombreLibro + "',cantidadSolicitadaLibroPrestamo='" + cantidadLibro + "',fechaPrestamo='" + Fecha + "' Where codigoPrestamo=" + codigoPrestamo, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }
    }
}