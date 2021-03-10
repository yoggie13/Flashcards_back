using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Like
    {
        [Key, Column(Order = 0)]
        public User UserID { get; set; }
        [Key, Column(Order = 1)]
        public DeckOfCards DeckOfCardsID { get; set; }
    }
}
