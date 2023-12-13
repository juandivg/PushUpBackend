using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Programacion: BaseEntity
    {
        public int idContrato { get; set; }
        public Contrato Contrato { get; set; }
        public int idTurno { get; set; }
        public Turno Turno { get; set; }
        public int idEmpleado { get; set; }
        public Persona Empleado { get; set; }
    }
}