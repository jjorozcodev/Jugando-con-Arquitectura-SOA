using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace wsRegistroDepositos
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static readonly List<Usuario> usuariosLista = new List<Usuario>();
        private static int siguienteId = 0;

        public void Agregar(Usuario usuario)
        {
            usuario.UsuarioId = ++siguienteId;
            usuariosLista.Add(usuario);
        }

        public void Guardar(Usuario usuarioActualizado)
        {
            Usuario usuarioL = usuariosLista.SingleOrDefault(u => u.UsuarioId == usuarioActualizado.UsuarioId);
            if (usuarioL != null)
            {
                usuarioL.Nombre = usuarioActualizado.Nombre;
                usuarioL.Meta = usuarioActualizado.Meta;
                usuarioL.Total = usuarioActualizado.Total;
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuarioL = usuariosLista.SingleOrDefault(u => u.UsuarioId == id);
            if (usuarioL == null)
            {
                return null;
            }
            return new Usuario { Nombre = usuarioL.Nombre, Meta = usuarioL.Meta, Total = usuarioL.Total, UsuarioId = usuarioL.UsuarioId };
        }

        public ReadOnlyCollection<Usuario> ObtenerTodos()
        {
            return usuariosLista.AsReadOnly();
        }
    }
}
