using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models.DTOs
{
    public class ExamenDto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<PreguntaDto> Preguntas { get; set; }
    }
}
