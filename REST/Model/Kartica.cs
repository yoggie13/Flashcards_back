using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Kartica
    {
        public int KarticaID { get; set; }
        public SkupKartica SkupKarticaID { get; set; }
        public string TekstFront { get; set; }
        public string TekstBack { get; set; }
    }
}
