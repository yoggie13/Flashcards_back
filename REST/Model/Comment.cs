using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public User UserID { get; set; }
        public DeckOfCards DeckOfCardsID { get; set; }
        public string Text { get; set; }

    }
}
