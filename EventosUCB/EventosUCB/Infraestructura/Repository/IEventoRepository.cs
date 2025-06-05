using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{
    public interface IEventoRepository
    {
        Task<Evento> GetByIdAsync(string id);
        Task SaveAsync(Evento evento);
        Task<List<Evento>> GetAllAsync();
    }
}