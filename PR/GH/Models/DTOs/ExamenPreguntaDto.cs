using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models.DTOs
{
    public class ExamenPreguntaDto
    {
        public int ExamenId { get; set; }
        public virtual Examen Examen { get; set; }
        public int PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }
    }
}
