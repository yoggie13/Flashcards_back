using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Card
    {
        [Key, Column(Order = 1)]
        public int CardID { get; set; }
        [Key, Column(Order = 0)]
        public DeckOfCards DeckOfCardsID { get; set; }
        public string TextFront { get; set; }
        public string TextBack { get; set; }

    }
}
