using System.Collections.Generic;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;

namespace EventosUCB.Infraestructura.Repository
{

    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly List<Inscripcion> _inscripciones = new();

        public Task SaveAsync(Inscripcion inscripcion)
        {
            _inscripciones.Add(inscripcion);
            return Task.CompletedTask;
        }
    }
}
