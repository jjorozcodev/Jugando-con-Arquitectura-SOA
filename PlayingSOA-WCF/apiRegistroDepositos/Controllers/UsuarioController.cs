using apiRegistroDepositos.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace apiRegistroDepositos.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio(); 
        public int Put(int id, [FromBody]int cantidad)
        {
            Usuario u = repositorio.ObtenerPorId(id);
            if (u == null)
            {
                return -1;
            }
            u.Total += cantidad;
            repositorio.Guardar(u);
            return u.Total;
        }

        public int Post([FromBody]UsuarioRequest usuario)
        {
            Usuario u = new Usuario { Nombre = usuario.Nombre, Meta = usuario.Meta, Total = 0 };
            repositorio.Agregar(u);
            return u.UsuarioId;
        }

        public IEnumerable<Usuario> Get()
        {
            return new List<Usuario>(repositorio.ObtenerTodos());
        }

        public class UsuarioRequest
        {
            public string Nombre { get; set; }
            public int Meta { get; set; }
        }
    }
}