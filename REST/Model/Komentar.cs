using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Komentar
    {
        public int KomentarID { get; set; }
        public Korisnik KorisnikID { get; set; }
        public SkupKartica SkupKarticaID { get; set; }
        public string Tekst { get; set; }

    }
}
