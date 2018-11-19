using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class OpcionPregunta
    {
        public int Id { get; set; }

        public int OpcionId { get; set; }
        public virtual Opcion Opcion { get; set; }
        public int PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }

        public OpcionPregunta(int OpcionId, int PreguntaId)
        {
            this.OpcionId = OpcionId;
            this.PreguntaId = PreguntaId;
        }


    }
}
