using System;

namespace EventosUCB.Domain.Entities
{
    public class Inscripcion
    {
        public string EventoId { get; private set; }
        public string UsuarioCI { get; private set; }
        public DateTime FechaInscripcion { get; private set; }
        public double MontoPagado { get; private set; }

        public Inscripcion(string eventoId, string usuarioCI, DateTime fechaInscripcion, double montoPagado)
        {
            EventoId = eventoId;
            UsuarioCI = usuarioCI;
            FechaInscripcion = fechaInscripcion;
            MontoPagado = montoPagado;
        }
    }
}