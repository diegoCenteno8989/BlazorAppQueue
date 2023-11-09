using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime TiempoRegistro { get; set; }
        public int ColaId { get; set; }
    }

    public class PersonaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ColaId { get; set; }
    }

}
