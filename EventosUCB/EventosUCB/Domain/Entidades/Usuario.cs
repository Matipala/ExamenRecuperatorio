namespace EventosUCB.Domain.Entities
{
    public class Usuario
    {
        public string Nombre { get; private set; }
        public string CI { get; private set; }

        public Usuario(string nombre, string ci)
        {
            Nombre = nombre;
            CI = ci;
        }
    }
}
