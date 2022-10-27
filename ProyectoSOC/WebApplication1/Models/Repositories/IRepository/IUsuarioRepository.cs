using ProyectoSOC.Models.Entity;

namespace ProyectoSOC.Models.Repositories.IRepository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool ExisteUsuario(int usuarioId);
        Usuario Login(string usuario, string usuarioPassword);
        bool ExisteUsuarioNombre(string usuarioUsuario);
        Usuario GetUsuario(string usuarioUsuario);
        string CrearPasswordHash(string usuarioPass);
    }
}
