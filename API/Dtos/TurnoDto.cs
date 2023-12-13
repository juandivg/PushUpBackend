using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TurnoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TimeOnly HoraTurnoI  { get; set; }
        public TimeOnly HoraTurnoF { get; set; }
    }
}