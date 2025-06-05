using System;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;
using EventosUCB.Infraestructura.Repository;

namespace EventosUCB.Application
{
    public interface IRegistrarUsuarioUseCase
    {
        Task<RegistrarUsuarioResponse> ExecuteAsync(RegistrarUsuarioRequest request);
    }

    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IInscripcionRepository _inscripcionRepository;

        public RegistrarUsuarioUseCase(
            IEventoRepository eventoRepository,
            IUsuarioRepository usuarioRepository,
            IInscripcionRepository inscripcionRepository)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _inscripcionRepository = inscripcionRepository;
        }

        public async Task<RegistrarUsuarioResponse> ExecuteAsync(RegistrarUsuarioRequest request)
        {
            var evento = await _eventoRepository.GetByIdAsync(request.EventoId);
            if (evento == null)
            {
                return new RegistrarUsuarioResponse
                {
                    Success = false,
                    Message = "El evento no existe."
                };
            }

            if (evento.EsEventoPasado())
            {
                return new RegistrarUsuarioResponse
                {
                    Success = false,
                    Message = "No se puede registrar en eventos pasados."
                };
            }

            if (evento.EstaLleno())
            {
                return new RegistrarUsuarioResponse
                {
                    Success = false,
                    Message = "El evento ya está lleno."
                };
            }

            if (evento.YaRegistrado(request.CI))
            {
                return new RegistrarUsuarioResponse
                {
                    Success = false,
                    Message = "El usuario ya está registrado en el evento."
                };
            }

            var usuarioExistente = await _usuarioRepository.GetByCIAsync(request.CI);
            Usuario usuario;
            if (usuarioExistente == null)
            {
                usuario = new Usuario(Guid.NewGuid().ToString(), request.Nombre, request.CI);
                await _usuarioRepository.SaveAsync(usuario);
            }
            else
            {
                usuario = usuarioExistente;
            }

            evento.RegistrarUsuario(usuario);
            await _eventoRepository.SaveAsync(evento);

            var inscripcion = new Inscripcion(Guid.NewGuid().ToString(), evento.Id, usuario.Id, DateTime.Now);
            await _inscripcionRepository.SaveAsync(inscripcion);

            return new RegistrarUsuarioResponse
            {
                Success = true,
                Message = "Usuario registrado con éxito",
                Evento = evento
            };
        }
    }

    public class RegistrarUsuarioRequest
    {
        public string EventoId { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }
    }

    public class RegistrarUsuarioResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Evento Evento { get; set; }
    }
}
