using System.Collections.Generic;
using System.Web.Services;

namespace wsRegistroDepositos
{
    [WebService(Namespace = "https://www.uca.edu.ni/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class wsRegistroDepositos : WebService, IServicioDepositos
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();

        public int AgregarDeposito(int cantidad, int idUsuario)
        {
            Usuario u = repositorio.ObtenerPorId(idUsuario);
            if (u == null)
            {
                return -1;
            }
            u.Total += cantidad;
            repositorio.Guardar(u);
            return u.Total;
        }

        public int AgregarUsuario(string nombre, int meta)
        {
            Usuario u = new Usuario { Nombre = nombre, Meta = meta, Total = 0 };
            repositorio.Agregar(u);
            return u.UsuarioId;
        }

        public List<Usuario> ListaUsuarios()
        {
            return new List<Usuario>(repositorio.ObtenerTodos());
        }
    }
}
