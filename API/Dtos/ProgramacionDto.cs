using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProgramacionDto
    {
        public int Id { get; set; }
        public int idContrato { get; set; }
        public int idTurno { get; set; }

        public int idEmpleado { get; set; }
       
    }
}