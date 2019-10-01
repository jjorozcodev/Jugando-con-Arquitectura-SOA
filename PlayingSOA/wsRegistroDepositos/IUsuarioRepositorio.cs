using System.Collections.ObjectModel;

namespace wsRegistroDepositos
{
    public interface IUsuarioRepositorio
    {
        void Agregar(Usuario usuario);
        ReadOnlyCollection<Usuario> ObtenerTodos();
        Usuario ObtenerPorId(int id);
        void Guardar(Usuario usuarioActualizado);
    }
}
