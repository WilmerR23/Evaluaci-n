using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class Pregunta
    {

        public Pregunta(string Texto)
        {
            this.Texto = Texto;
        }

        public int Id { get; set; }
        public string Texto { get; set; }

        public virtual ICollection<ExamenPregunta> ExamenPregunta { get; set; }



    }
}
