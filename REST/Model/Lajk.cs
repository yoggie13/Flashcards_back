using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Lajk
    {
        public int PodkomentarID { get; set; }
        public Komentar KomentarID { get; set; }
        public Korisnik KorisnikID { get; set; }
        public SkupKartica SkupKarticaID { get; set; }
        public string Tekst { get; set; }
        public Korisnik PodkomentarisaoID { get; set; }
    }
}
