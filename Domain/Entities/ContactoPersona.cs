using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactoPersona: BaseEntity
    {
        public string Descripcion { get; set; }
        public int idPersona { get; set; }
        public Persona Persona { get; set; }
        public int idTContacto { get; set; }
        public TipoContacto TipoContacto { get; set; }
    }
}