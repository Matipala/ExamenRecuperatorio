using System.Collections.Generic;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{
    public interface IInscripcionRepository
    {
        Task SaveAsync(Inscripcion inscripcion);
        Task<List<Inscripcion>> GetByUsuarioIdAsync(string usuarioId);

    }
}
