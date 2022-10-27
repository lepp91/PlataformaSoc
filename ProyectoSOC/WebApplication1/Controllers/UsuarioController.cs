using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSOC.Data;
using ProyectoSOC.Models.Entity;
using ProyectoSOC.Models.Repositories.IRepository;
using ProyectoSOC.Models.ViewModels;

namespace ProyectoSOC.Controllers
{
    [Route("SOC/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly SocDB _context;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger, IMapper mapper, IConfiguration config, SocDB context)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
            _mapper = mapper;
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(UsuarioLoginViewModel model)
        {
            var ExisteUsuario = _usuarioRepository.GetUsuario(model.Usuario);
            if (ExisteUsuario == null)
            {
                return BadRequest("Datos incorrectos");
            }

            var result = _usuarioRepository.Login(model.Usuario, model.Password);
            if (result == null)
            {
                int MaxIntentosSesion = 3;
                var usuarioIntentos = _usuarioRepository.GetUsuario(model.Usuario);
                if (usuarioIntentos.UsuarioEstado == false)
                {
                    return Unauthorized("Datos incorrectos");
                }

                if (usuarioIntentos.UsuarioIntentos == MaxIntentosSesion)
                {
                    usuarioIntentos.UsuarioEstado = false;
                    usuarioIntentos.UsuarioIntentos = 0;
                    _usuarioRepository.Update(usuarioIntentos);
                    return Unauthorized("Contacte con su administrador en caso no pueda iniciar sesión");
                }

                usuarioIntentos.UsuarioIntentos += 1;
                _usuarioRepository.Update(usuarioIntentos);
                int Intentos = MaxIntentosSesion - usuarioIntentos.UsuarioIntentos;

                return Unauthorized("Podria deshabilitar la cuenta si sigue con intentos fallidos");
            }

            if (result.UsuarioEstado == false)
            {
                return Unauthorized("Contacte con su administrador en caso no pueda iniciar sesión");
            }



            return Ok(1);
        }

        [HttpPost]
        public ActionResult PostUsuario(UsuarioViewModel model)
        {
            if (_usuarioRepository.ExisteUsuarioNombre(model.Usuario))
            {
                return BadRequest($"El usuario ya existe");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var usuario = _mapper.Map<Usuario>(model);
                    usuario.UsuarioPassword = _usuarioRepository.CrearPasswordHash(model.Password);
                    usuario.UsuarioPasswordAnterior = _usuarioRepository.CrearPasswordHash(model.Password);
                    usuario.UsuarioFechaCreacion = DateTime.Now;
                    usuario.UsuarioFechaModificacion = DateTime.Now;
                    usuario.UsuarioFechaSesion = DateTime.Now;
                    usuario.UsuarioCambioPass = false;
                    usuario.UsuarioIntentos = 0;
                    usuario.UsuarioEstado = true;

                    int result = _usuarioRepository.Create(usuario);
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                    return BadRequest("error en la creacion");
                }
            }

            return Ok(1);
        }

        [HttpGet]
        public ActionResult GetUsuario()
        {
            try
            {
                var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());
                

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener usuario {ex}");
                return BadRequest($"Error al obtener usuario {ex}");
            }
        }
    }
}
