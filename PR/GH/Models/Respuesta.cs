using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public Respuesta(string texto)
        {
            this.Texto = texto;
        }
    }
}
