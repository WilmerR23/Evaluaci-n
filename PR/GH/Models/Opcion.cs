using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public Opcion(string texto)
        {
            this.Texto = texto;
        }
    }
}
