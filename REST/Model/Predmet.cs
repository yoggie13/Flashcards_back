using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Predmet
    {
        public int PredmetID { get; set; }
        public string Naziv { get; set; }
        public int GodinaStudija { get; set; }
        public int Semestar { get; set; }
        public Smer Smer { get; set; }
    }
}
