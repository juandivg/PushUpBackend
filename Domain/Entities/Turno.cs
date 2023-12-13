using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Turno: BaseEntity
    {
        public string Nombre { get; set; }
        public TimeOnly HoraTurnoI  { get; set; }
        public TimeOnly HoraTurnoF { get; set; }
        public ICollection<Programacion> Programaciones { get; set; }
    }
}