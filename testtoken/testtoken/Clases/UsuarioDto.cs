using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testtoken.Clases
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Logueado { get; set; }
        public byte[] Foto { get; set; }
        public Nullable<System.DateTime> FechaUltIngreso { get; set; }
    }
}