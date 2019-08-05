using Proyecto_Sistema_Bibliotecario_UH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Sistema_Bibliotecario_UH.Controllers
{
    public class HomeController : Controller
    {
        public static Metodos objMetodos = new Metodos();
        public static Usuario usuario = new Usuario();
        public static Libros libro = new Libros();
        public static Prestamos prestamo = new Prestamos();
        public static int modificarUsuario = 0;
        public static int modificarLibro = 0;
        public static int modificarPrestamo = 0;


        //*******************************Inicio Pagina Principal*******************************
        // Inicio Pagina Principal
        public ActionResult Index()
        {
            usuario = new Usuario();
            return View();
        }

        [HttpPost]
        public ViewResult Index(Usuario usuario)
        {
            try
            {
                DataSet ds = objMetodos.ValidarUsuarioIngresado();
                DataTable tabla = ds.Tables[0];

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    int registroCedula = (int)tabla.Rows[i][0];
                    string registroContrasena = tabla.Rows[i][1].ToString();

                    if (usuario.cedulaUsuario == registroCedula && usuario.contrasenaUsuario.Equals(registroContrasena))
                    {
                        usuario.cedulaUsuario = (int)tabla.Rows[i][0];
                        usuario.contrasenaUsuario = tabla.Rows[i][1].ToString();
                        usuario.nombreUsuario = tabla.Rows[i][2].ToString();
                        usuario.apellidosUsuario = tabla.Rows[i][3].ToString();
                        usuario.direccionUsuario = tabla.Rows[i][4].ToString();
                        usuario.tipoUsuario = tabla.Rows[i][5].ToString();
                    }
                }

                if (usuario.tipoUsuario.Equals("regular"))
                {
                    return View("MenuUsuario", usuario);
                }
                else
                {
                    if (usuario.tipoUsuario.Equals("socio"))
                    {
                        return View("MenuSocio", usuario);
                    }
                    else
                    {
                        if (usuario.tipoUsuario.Equals("bibliotecario"))
                        {
                            return View("MenuBibliotecario", usuario);
                        }
                        else
                        {
                            ViewBag.mensaje = "Los datos ingresados no coinciden";
                            return View();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Los datos ingresados no coinciden";
                return View();
            }
        }

        //*******************************Paginas Usuario*******************************
        // Menu Usuario
        [HttpGet]
        public ActionResult MenuUsuario(Usuario usuario)
        {
            return View();
        }
        // Menu Busqueda Libros Usuario
        [HttpGet]
        public ActionResult BusquedaUsuario(Usuario usuario)
        {
            DataSet ds = objMetodos.MostrarLibros();
            DataTable tablaLibros = ds.Tables[0];
            Libros libros = new Libros
            {
                tabla = tablaLibros
            };
            return View(libros);
        }

        //*******************************Paginas Socio*******************************
        // Menu Socio
        [HttpGet]
        public ActionResult MenuSocio()
        {
            return View();
        }
        // Ingresar nuevo Socio
        [HttpGet]
        public ActionResult NuevoSocio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoSocio(Usuario usuario)
        {
            try
            {
                objMetodos.InsertarUsuario(usuario.cedulaUsuario, usuario.contrasenaUsuario, usuario.nombreUsuario, usuario.apellidosUsuario, usuario.direccionUsuario, "socio");
                return View("MenuSocio");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al crear usuario";
                return View();
            }
        }
        // Modificar Socio
        [HttpGet]
        public ActionResult ModificarSocio()
        {
            DataSet ds = objMetodos.MostrarSocio();
            DataTable tabla = ds.Tables[0];
            Usuario usuario = new Usuario
            {
                tabla = tabla
            };
            return View(usuario);
        }

        [HttpPost]
        public ActionResult ModificarSocio(int cedula)
        {
            usuario.cedulaUsuario = cedula;
            DataSet ds = objMetodos.FiltrarUsuario(usuario.cedulaUsuario);
            DataTable tabla = ds.Tables[0];

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                usuario.cedulaUsuario = (int)tabla.Rows[i][0];
                usuario.contrasenaUsuario = tabla.Rows[i][1].ToString();
                usuario.nombreUsuario = tabla.Rows[i][2].ToString();
                usuario.apellidosUsuario = tabla.Rows[i][3].ToString();
                usuario.direccionUsuario = tabla.Rows[i][4].ToString();
                usuario.tipoUsuario = tabla.Rows[i][5].ToString();
                modificarUsuario = usuario.cedulaUsuario;
            }
            return View("~/Views/Home/Modificar.cshtml", usuario);
        }
        //Modificar Datos
        [HttpGet]
        public ActionResult Modificar()
        {
            int cedula = usuario.cedulaUsuario;
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(Usuario usuario)
        {
            try
            {
                objMetodos.ModificarSocio(modificarUsuario, usuario.contrasenaUsuario, usuario.nombreUsuario, usuario.apellidosUsuario, usuario.direccionUsuario, "socio");

                DataSet ds = objMetodos.MostrarSocio();
                DataTable tabla = ds.Tables[0];
                Usuario usuario2 = new Usuario
                {
                    tabla = tabla
                };
                return View("ModificarSocio", usuario2);
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al actualizar usuario";
                return View();
            }

        }
        // Eliminar Socio
        [HttpGet]
        public ActionResult EliminarSocio()
        {
            DataSet ds = objMetodos.MostrarSocio();
            DataTable tabla = ds.Tables[0];
            Usuario usuario = new Usuario
            {
                tabla = tabla
            };
            return View(usuario);
        }
        [HttpPost]
        public ActionResult EliminarSocio(int cedula)
        {
            objMetodos.EliminarUsuario(cedula);
            DataSet ds = objMetodos.MostrarSocio();
            DataTable tabla = ds.Tables[0];
            Usuario usuario = new Usuario
            {
                tabla = tabla
            };
            return View("EliminarSocio", usuario);
        }

        //*******************************Paginas Bibliotecario*******************************
        // Inicio Bibliotecario
        [HttpGet]
        public ActionResult MenuBibliotecario()
        {
            return View();
        }
        // Ver Socios
        [HttpGet]
        public ActionResult BibliotecarioSocios(Usuario usuario)
        {
            DataSet ds = objMetodos.MostrarUsuarios();
            DataTable tablausuarios = ds.Tables[0];
            Usuario listaUsuarios = new Usuario
            {
                tabla = tablausuarios
            };
            return View(listaUsuarios);
        }

        // Bibliotecario Gestion Libros
        [HttpGet]
        public ActionResult GestionLibros()
        {
            return View();
        }

        // Bibliotecario Insertar Libros
        [HttpGet]
        public ActionResult GestionLibrosInsertar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GestionLibrosInsertar(Libros libro)
        {
            try
            {
                if (libro.asignaturaLibro.Equals("Fantasia"))
                {
                    libro.ubicacionLibro = "Sector-1";
                }
                else
                {
                    if (libro.asignaturaLibro.Equals("Terror"))
                    {
                        libro.ubicacionLibro = "Sector-2";
                    }
                    else
                    {
                        if (libro.asignaturaLibro.Equals("Educación"))
                        {
                            libro.ubicacionLibro = "Sector-3";
                        }
                        else
                        {
                            if (libro.asignaturaLibro.Equals("Idiomas"))
                            {
                                libro.ubicacionLibro = "Sector-4";
                            }
                            else
                            {
                                if (libro.asignaturaLibro.Equals("Novelas"))
                                {
                                    libro.ubicacionLibro = "Sector-5";
                                }
                                else
                                {
                                    if (libro.asignaturaLibro.Equals("Comics"))
                                    {
                                        libro.ubicacionLibro = "Sector-6";
                                    }
                                    else
                                    {
                                        if (libro.asignaturaLibro.Equals("Niños"))
                                        {
                                            libro.ubicacionLibro = "Sector-7";
                                        }
                                        else
                                        {
                                            if (libro.asignaturaLibro.Equals("Hogar"))
                                            {
                                                libro.ubicacionLibro = "Sector-8";
                                            }
                                            else
                                            {
                                                if (libro.asignaturaLibro.Equals("Revistas"))
                                                {
                                                    libro.ubicacionLibro = "Sector-9";
                                                }
                                                else
                                                {
                                                    if (libro.asignaturaLibro.Equals("Historia"))
                                                    {
                                                        libro.ubicacionLibro = "Sector-10";
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                objMetodos.InsertarLibro(libro.tituloLibro, libro.autorLibro, libro.cantidadLibro, libro.ubicacionLibro, libro.asignaturaLibro);
                return View("GestionLibros");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al crear usuario";
                return View();
            }
        }

        // Eliminar Libro
        [HttpGet]
        public ActionResult GestionLibroEliminar()
        {
            DataSet ds = objMetodos.MostrarLibrosCompletos();
            DataTable tabla = ds.Tables[0];
            Libros libro = new Libros
            {
                tabla = tabla
            };
            return View(libro);
        }
        [HttpPost]
        public ActionResult GestionLibroEliminar(int codigo)
        {
            objMetodos.EliminarLibro(codigo);
            DataSet ds = objMetodos.MostrarLibrosCompletos();
            DataTable tabla = ds.Tables[0];
            Libros libro = new Libros
            {
                tabla = tabla
            };
            return View("GestionLibroEliminar", libro);
        }

        // Modificar Gestion Libros
        [HttpGet]
        public ActionResult GestionLibrosModificar()
        {
            DataSet ds = objMetodos.MostrarLibrosCompletos();
            DataTable tabla = ds.Tables[0];
            Libros libro = new Libros
            {
                tabla = tabla
            };
            return View(libro);
        }

        [HttpPost]
        public ActionResult GestionLibrosModificar(int codigo)
        {
            libro.codigoLibro = codigo;
            DataSet ds = objMetodos.FiltrarLibro(libro.codigoLibro);
            DataTable tabla = ds.Tables[0];

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                libro.codigoLibro = (int)tabla.Rows[i][0];
                libro.tituloLibro = tabla.Rows[i][1].ToString();
                libro.autorLibro = tabla.Rows[i][2].ToString();
                libro.cantidadLibro = (int)tabla.Rows[i][3];
                libro.ubicacionLibro = tabla.Rows[i][4].ToString();
                libro.asignaturaLibro = tabla.Rows[i][5].ToString();
                modificarLibro = libro.codigoLibro;
            }
            return View("~/Views/Home/ModificarLibro.cshtml", libro);
        }
        //Modificar Datos
        [HttpGet]
        public ActionResult ModificarLibro()
        {
            int codigo = libro.codigoLibro;
            return View();
        }
        [HttpPost]
        public ActionResult ModificarLibro(Libros libro)
        {
            try
            {
                if (libro.asignaturaLibro.Equals("Fantasia"))
                {
                    libro.ubicacionLibro = "Sector-1";
                }
                else
                {
                    if (libro.asignaturaLibro.Equals("Terror"))
                    {
                        libro.ubicacionLibro = "Sector-2";
                    }
                    else
                    {
                        if (libro.asignaturaLibro.Equals("Educación"))
                        {
                            libro.ubicacionLibro = "Sector-3";
                        }
                        else
                        {
                            if (libro.asignaturaLibro.Equals("Idiomas"))
                            {
                                libro.ubicacionLibro = "Sector-4";
                            }
                            else
                            {
                                if (libro.asignaturaLibro.Equals("Novelas"))
                                {
                                    libro.ubicacionLibro = "Sector-5";
                                }
                                else
                                {
                                    if (libro.asignaturaLibro.Equals("Comics"))
                                    {
                                        libro.ubicacionLibro = "Sector-6";
                                    }
                                    else
                                    {
                                        if (libro.asignaturaLibro.Equals("Niños"))
                                        {
                                            libro.ubicacionLibro = "Sector-7";
                                        }
                                        else
                                        {
                                            if (libro.asignaturaLibro.Equals("Hogar"))
                                            {
                                                libro.ubicacionLibro = "Sector-8";
                                            }
                                            else
                                            {
                                                if (libro.asignaturaLibro.Equals("Revistas"))
                                                {
                                                    libro.ubicacionLibro = "Sector-9";
                                                }
                                                else
                                                {
                                                    if (libro.asignaturaLibro.Equals("Historia"))
                                                    {
                                                        libro.ubicacionLibro = "Sector-10";
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                objMetodos.ModificarLibro(modificarLibro, libro.tituloLibro, libro.autorLibro, libro.cantidadLibro, libro.ubicacionLibro, libro.asignaturaLibro);

                DataSet ds = objMetodos.MostrarLibrosCompletos();
                DataTable tabla = ds.Tables[0];
                Libros libros2 = new Libros
                {
                    tabla = tabla
                };
                return View("GestionLibrosModificar", libros2);
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al actualizar usuario";
                return View();
            }
        }

        //*****************************Gestion de Prestamos*****************************
        [HttpGet]
        public ActionResult GestionPrestamo()
        {
            return View();
        }

        //Mostrar Datos Prestamos
        [HttpGet]
        public ActionResult GestionPrestamosMostrar()
        {
            DataSet ds = objMetodos.MostrarPrestamos();
            DataTable tablaPrestamos = ds.Tables[0];
            Prestamos prestamosRealizandos = new Prestamos
            {
                tabla = tablaPrestamos
            };
            return View(prestamosRealizandos);
        }

        //Mostrar Socios No Fiables
        [HttpGet]
        public ActionResult GestionPrestamosNoFiables()
        {
            DataSet ds = objMetodos.MostrarNoFiables();
            DataTable tablaPrestamos = ds.Tables[0];
            UsuariosNoFiables noFiables = new UsuariosNoFiables
            {
                tabla = tablaPrestamos
            };
            return View(noFiables);
        }

        //Ingresar Prestamo nuevo
        [HttpGet]
        public ActionResult GestionPrestamoNuevo()
        {           
            return View();
        }

        //Guardar Prestamo nuevo
        [HttpPost]
        public ActionResult GestionPrestamoNuevo(Prestamos prestamo)
        {
            try
            {
                String fecha = DateTime.Now.ToString("dd.MM.yyy");
                objMetodos.InsertarPrestamo(prestamo.nombreSocioPrestamo, prestamo.nombreLibroPrestamo, prestamo.cantidadSolicitadaLibroPrestamo, fecha );
                return View("GestionPrestamo");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al crear usuario";
                return View();
            }
        }

        //Eliminar Prestamo 
        [HttpGet]
        public ActionResult GestionPrestamoEliminar()
        {
            DataSet ds = objMetodos.MostrarPrestamos();
            DataTable tabla = ds.Tables[0];
            Prestamos prestamo = new Prestamos
            {
                tabla = tabla
            };
            return View(prestamo);
        }

        [HttpPost]
        public ActionResult GestionPrestamoEliminar(int codigo)
        {
            objMetodos.EliminarPrestamo(codigo);
            DataSet ds = objMetodos.MostrarPrestamos();
            DataTable tabla = ds.Tables[0];
            Prestamos prestamo = new Prestamos
            {
                tabla = tabla
            };
            return View("GestionPrestamoEliminar", prestamo);
        }

        // Modificar Socio
        [HttpGet]
        public ActionResult GestionPrestamosModificar()
        {
            DataSet ds = objMetodos.MostrarPrestamos();
            DataTable tabla = ds.Tables[0];
            Prestamos prestamo = new Prestamos
            {
                tabla = tabla
            };
            return View(prestamo);
        }

        [HttpPost]
        public ActionResult GestionPrestamosModificar(int codigo)
        {
            prestamo.codigoPrestamo = codigo;
            DataSet ds = objMetodos.FiltrarPrestamo(prestamo.codigoPrestamo);
            DataTable tabla = ds.Tables[0];

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                prestamo.codigoPrestamo = (int)tabla.Rows[i][0];
                prestamo.nombreSocioPrestamo = tabla.Rows[i][1].ToString();
                prestamo.nombreLibroPrestamo = tabla.Rows[i][2].ToString();
                prestamo.cantidadSolicitadaLibroPrestamo = (int)tabla.Rows[i][3];
                prestamo.fechaPrestamo = tabla.Rows[i][4].ToString();
                modificarPrestamo = prestamo.codigoPrestamo;
            }
            return View("~/Views/Home/ModificarPrestamo.cshtml", prestamo);
        }
        //Modificar Datos
        [HttpGet]
        public ActionResult ModificarPrestamo()
        {
            int codigo = prestamo.codigoPrestamo;
            return View();
        }
        [HttpPost]
        public ActionResult ModificarPrestamo(Prestamos prestamo)
        {
            try
            {
                String fecha = DateTime.Now.ToString("dd.MM.yyy");
                objMetodos.ModificarPrestamo(modificarPrestamo, prestamo.nombreSocioPrestamo, prestamo.nombreLibroPrestamo, prestamo.cantidadSolicitadaLibroPrestamo, fecha);

                DataSet ds = objMetodos.MostrarPrestamos();
                DataTable tabla = ds.Tables[0];
                Prestamos prestamo2 = new Prestamos
                {
                    tabla = tabla
                };
                return View("GestionPrestamosModificar", prestamo2);
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error al actualizar prestamo";
                return View();
            }
        }
    }
}