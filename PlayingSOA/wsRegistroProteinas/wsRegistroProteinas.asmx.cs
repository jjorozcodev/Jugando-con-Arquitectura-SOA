using System.Collections.Generic;
using System.Web.Services;

namespace wsRegistroProteinas
{
    [WebService(Namespace = "https://www.uca.edu.ni/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class wsRegistroProteinas : WebService
    {

        [WebMethod(Description = "Incrementa un monto al total acumulado.")]
        public int AgregarProteina(int cantidad)
        {

            return cantidad;
        }

        [WebMethod(Description = "Agrega un usuario al almacén de datos.")]
        public int AgregarUsuario(string nombre, int meta)
        {
            int usuarioId = 0;
            Usuario usuario = new Usuario { Nombre = nombre, Meta = meta, Total = 0, UsuarioId =+ usuarioId + 1 };
            int control = usuario.UsuarioId;

            return control;
        }

        [WebMethod(Description = "Listado de usuarios.")]
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> usuariosLista = new List<Usuario>();
            int i = 0;
            usuariosLista.Add(new Usuario { Nombre = "Andrew", Meta = 5750, Total = 0, UsuarioId = ++i });
            usuariosLista.Add(new Usuario { Nombre = "Joseph", Meta = 7500, Total = 0, UsuarioId = ++i });
            usuariosLista.Add(new Usuario { Nombre = "Maxim", Meta = 10000, Total = 0, UsuarioId = ++i });

            return usuariosLista;
        }
    }
}
