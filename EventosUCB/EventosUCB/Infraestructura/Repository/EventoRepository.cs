using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly List<Evento> _eventos = new();

        public EventoRepository()
        {
            _eventos.Add(new Evento
            {
                Id = "1",
                Nombre = "ICPC 2025",
                Fecha = DateTime.Now.AddDays(5),
                Costo = 25,
                Capacidad = 100
            });
        }

        public Task<Evento> GetByIdAsync(string id) =>
            Task.FromResult(_eventos.FirstOrDefault(e => e.Id == id));

        public Task SaveAsync(Evento evento)
        {
            return Task.CompletedTask;
        }
    }
}
