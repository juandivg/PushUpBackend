using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona: BaseEntity
    {
        public string idPersona { get; set; }
        public string Nombre { get; set; }
        public DateTime dateReg { get; set; }
        public int IdTPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public int IdCat { get; set; }
        public CategoriaPersona CategoriaPersona { get; set; }
        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
        public ICollection<DirPersona> dirPersonas { get; set; }
        public ICollection<ContactoPersona> ContactoPersonas { get; set; }
        public ICollection<Contrato> ContratosCliente { get; set; }
        public ICollection<Contrato> ContratosEmpleado { get; set; }
        public ICollection<Programacion> Programaciones { get; set; }
    }
}