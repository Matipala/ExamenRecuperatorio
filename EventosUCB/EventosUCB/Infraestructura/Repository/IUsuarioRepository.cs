using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByCIAsync(string ci);
        Task SaveAsync(Usuario usuario);
    }
}
