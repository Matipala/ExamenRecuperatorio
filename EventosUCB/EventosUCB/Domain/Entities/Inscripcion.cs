using System;

namespace EventosUCB.Domain.Entities
{
    public class Inscripcion
    {
        public string Id { get; set; }
        public string EventoId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public Inscripcion(string id, string eventoId, string usuarioId, DateTime fecha)
        {
            Id = id;
            EventoId = eventoId;
            UsuarioId = usuarioId;
            FechaInscripcion = fecha;
        }
    }
}
