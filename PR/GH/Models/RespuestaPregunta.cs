using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class RespuestaPregunta
    {
        public int Id { get; set; }
        public int RespuestaId { get; set; }
        public virtual Respuesta Respuesta { get; set; }
        public int PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }

        public RespuestaPregunta(int RespuestaId, int PreguntaId)
        {
            this.RespuestaId = RespuestaId;
            this.PreguntaId = PreguntaId;
        }
    }
}
