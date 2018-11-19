using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class ExamenPregunta
    {
        public int ExamenId { get; set; }
        public virtual Examen Examen { get; set; }
        public int PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }

        public ExamenPregunta(int ExamenId, int PreguntaId)
        {
            this.ExamenId = ExamenId;
            this.PreguntaId = PreguntaId;
        }
    }
}
