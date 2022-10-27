using ProyectoSOC.Data;
using ProyectoSOC.Models.Entity;
using ProyectoSOC.Models.Repositories.IRepository;
using System.Text;

namespace ProyectoSOC.Models.Repositories.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly SocDB _context;
        private readonly ILogger<Usuario> _logger;
        public UsuarioRepository(SocDB context, ILogger<Usuario> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool ExisteUsuario(int usuarioId)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.UsuarioId.Equals(usuarioId));
            if (usuario == null)
            {
                return false;
            }

            return true;
        }

        public Usuario GetUsuario(string usuarioUsuario)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.UsuarioUsuario.Equals(usuarioUsuario));
            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        public bool ExisteUsuarioNombre(string usuarioUsuario)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.UsuarioUsuario.Equals(usuarioUsuario));
            if (usuario == null)
            {
                return false;
            }

            return true;
        }

        public Usuario Login(string usuarioUsuario, string usuarioPassword)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.UsuarioUsuario.Equals(usuarioUsuario));
            if (usuario == null)
            {
                return null;
            }

            string pass = CrearPasswordHash(usuarioPassword);

            if(pass != usuario.UsuarioPassword)
            {
                return null;
            }

            return usuario;
        }

        public string CrearPasswordHash(string usuarioPass)
        {
            if (String.IsNullOrEmpty(usuarioPass))
            {
                return String.Empty;
            }

            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            byte[] HashByte = Encoding.UTF8.GetBytes(string.Concat(usuarioPass));
            byte[] encryptedByte = HashTool.ComputeHash(HashByte);
            HashTool.Clear();

            return Convert.ToBase64String(encryptedByte);
        }
    }
}
