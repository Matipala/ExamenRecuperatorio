using System;
using System.Collections.Generic;
using System.Linq;

namespace EventosUCB.Domain.Entities
{
    public class Evento
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        public int Capacidad { get; set; }
        public List<Usuario> UsuariosRegistrados { get; set; } = new();

        public bool EstaLleno() => UsuariosRegistrados.Count >= Capacidad;

        public bool EsEventoPasado() => Fecha < DateTime.Now;

        public bool YaRegistrado(string ci) =>
            UsuariosRegistrados.Any(u => u.CI == ci);

        public void RegistrarUsuario(Usuario usuario)
        {
            UsuariosRegistrados.Add(usuario);
        }
    }
}
