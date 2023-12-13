using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DirPersona: BaseEntity
    {
        public string Direccion { get; set; }
        public int idPersona { get; set; }
        public Persona Persona { get; set; }
        public int idTDireccion { get; set; }

        public TipoDireccion TipoDireccion { get; set; }
    }
}