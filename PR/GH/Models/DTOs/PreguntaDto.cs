using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models.DTOs
{
    public class PreguntaDto
    {
        public int Id { get; set; }
        
        public string Texto { get; set; }

        public int ExamenId { get; set; }

        public ICollection<OpcionDto> Opciones { get; set; }
        public ICollection<RespuestaDto> Respuestas { get; set; }
        public ICollection<ExamenDto> Examenes { get; set; }
    }
}
