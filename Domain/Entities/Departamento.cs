using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento: BaseEntity
    {
        public string nombreDep { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }
        public int idPais { get; set; }
        public Pais Pais { get; set; }
    }
}