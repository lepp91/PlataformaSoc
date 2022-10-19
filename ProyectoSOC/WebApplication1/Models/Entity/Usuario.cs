using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSOC.Models.Entity
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UsuarioUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioCorreo { get; set; }
        public string UsuarioPassword { get; set; }
        public string UsuarioPasswordAnterior { get; set; }
        public int UsuarioIntentos { get; set; }
        public bool UsuarioCambioPass { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UsuarioFechaCambioPass { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UsuarioFechaSesion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UsuarioFechaCreacion { get; set; }
        public DateTime UsuarioFechaModificacion { get; set; }
        public string UsuarioUsuarioId { get; set; }
        public bool UsuarioEstado { get; set; }
    }
}

