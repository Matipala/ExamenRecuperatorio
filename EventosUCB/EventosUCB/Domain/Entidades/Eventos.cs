using System;

namespace EventosUCB.Domain.Entities
{
    public class Evento
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Fecha { get; private set; }
        public double Costo { get; private set; }
        public int Capacidad { get; private set; }
        public int Inscritos { get; private set; }

        public Evento(string id, string nombre, string fecha, double costo, int capacidad)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;
            Costo = costo;
            Capacidad = capacidad;
            Inscritos = 0;
        }

        public bool TieneCapacidadDisponible()
        {
            return Inscritos < Capacidad;
        }

        public void IncrementarInscritos()
        {
            if (!TieneCapacidadDisponible())
            {
                throw new InvalidOperationException("Evento sin capacidad disponible");
            }
            Inscritos++;
        }

        public int ObtenerCapacidadDisponible()
        {
            return Capacidad - Inscritos;
        }
    }
}
