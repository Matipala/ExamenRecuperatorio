using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new();

        public Task<Usuario> GetByCIAsync(string ci) =>
            Task.FromResult(_usuarios.FirstOrDefault(u => u.CI == ci));

        public Task SaveAsync(Usuario usuario)
        {
            if (!_usuarios.Any(u => u.CI == usuario.CI))
                _usuarios.Add(usuario);

            return Task.CompletedTask;
        }
    }
}
