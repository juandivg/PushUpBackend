using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CiudadDto
    {
        public int Id { get; set; }
        public string nombreCiudad { get; set; }
        public int idDep { get; set; }
    }
}