using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Card
    {
        public int CardID { get; set; }
        public DeckOfCards DeckOfCardsID { get; set; }
        public string TextFront { get; set; }
        public string TextBack { get; set; }

    }
}
