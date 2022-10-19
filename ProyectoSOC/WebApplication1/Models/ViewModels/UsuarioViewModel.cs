namespace ProyectoSOC.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioLoginViewModel
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
