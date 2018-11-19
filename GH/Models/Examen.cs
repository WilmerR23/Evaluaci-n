using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class Examen
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Examen(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        public virtual ICollection<ExamenPregunta> ExamenPregunta { get; set; }


    }
}
