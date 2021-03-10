using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        [Key]
        public DeckOfCards DeckOfCardsID { get; set; }
        public string TextFront { get; set; }
        public string TextBack { get; set; }

    }
}
