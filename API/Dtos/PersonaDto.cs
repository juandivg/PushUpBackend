using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
              public string idPersona { get; set; }
        public string Nombre { get; set; }
        public DateTime dateReg { get; set; }
        public int IdTPersona { get; set; }
               public int IdCat { get; set; }

        public int IdCiudad { get; set; }

    }
}