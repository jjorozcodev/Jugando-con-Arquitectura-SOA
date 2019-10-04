using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wsRegistroDepositos
{
    public partial class WebFormDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static int AgregarDeposito(int cantidad, int idUsuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario u = repositorio.ObtenerPorId(idUsuario);
            if (u == null)
            {
                return -1;
            }
            u.Total += cantidad;
            repositorio.Guardar(u);
            return u.Total;
        }

        [WebMethod]
        public static int AgregarUsuario(string nombre, int meta)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario u = new Usuario { Nombre = nombre, Meta = meta, Total = 0 };
            repositorio.Agregar(u);
            return u.UsuarioId;
        }

        [WebMethod]
        public static List<Usuario> ListaUsuarios()
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            return new List<Usuario>(repositorio.ObtenerTodos());
        }
    }
}