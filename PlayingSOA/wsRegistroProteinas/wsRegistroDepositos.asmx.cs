using System.Collections.Generic;
using System.Web.Services;

namespace wsRegistroDepositos
{
    [WebService(Namespace = "https://www.uca.edu.ni/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class wsRegistroDepositos : WebService
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();

        [WebMethod(Description = "Agregar un monto al total acumulado.")]
        public int AgregarDeposito(int cantidad, int idUsuario)
        {
            Usuario u = repositorio.ObtenerPorId(idUsuario);
            if(u == null)
            {
                return -1;
            }
            u.Total += cantidad;
            repositorio.Guardar(u);
            return u.Total;
        }

        [WebMethod(Description = "Agrega un usuario al repositorio.")]
        public int AgregarUsuario(string nombre, int meta)
        {
            Usuario u = new Usuario { Nombre = nombre, Meta = meta, Total = 0 };
            repositorio.Agregar(u);
            return u.UsuarioId;
        }

        [WebMethod(Description = "Listado de usuarios en repositorio.")]
        public List<Usuario> ListaUsuarios()
        {
            return new List<Usuario>(repositorio.ObtenerTodos());
        }
    }
}
