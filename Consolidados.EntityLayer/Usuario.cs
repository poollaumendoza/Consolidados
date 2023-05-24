using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Persona oPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public Estado oEstado { get; set; }
    }
}