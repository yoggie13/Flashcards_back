using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class SkupKartica 
    {
        public int SkupKarticaID { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Korisnik KorisnikID { get; set; }
        public Predmet PredmetID { get; set; }

       
    }
}
