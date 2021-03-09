using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Like
    {
        public User UserID { get; set; }
        public DeckOfCards DeckOfCardsID { get; set; }
    }
}
