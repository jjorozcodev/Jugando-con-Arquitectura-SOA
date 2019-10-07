using System.Collections.ObjectModel;

namespace apiRegistroDepositos.Models
{
    interface IUsuarioRepositorio
    {
        void Agregar(Usuario usuario);
        ReadOnlyCollection<Usuario> ObtenerTodos();
        Usuario ObtenerPorId(int id);
        void Guardar(Usuario usuarioActualizado);
    }
}
