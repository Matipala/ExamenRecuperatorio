namespace EventosUCB.Domain.Entities
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }

        public Usuario(string id, string nombre, string ci)
        {
            Id = id;
            Nombre = nombre;
            CI = ci;
        }
    }
}
