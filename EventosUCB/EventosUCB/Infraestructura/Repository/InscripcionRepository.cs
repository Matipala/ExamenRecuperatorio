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


        public Task<List<Inscripcion>> GetByUsuarioIdAsync(string usuarioId)
        {
            var resultado = _inscripciones
                .Where(i => i.UsuarioId == usuarioId)
                .ToList();
            return Task.FromResult(resultado);
        }
    }
}
