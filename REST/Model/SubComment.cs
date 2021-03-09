using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class SubComment
    {
        public int SubCommentID { get; set; }
        public Comment CommentID { get; set; }
        public User UserID { get; set; }
        public DeckOfCards DeckOfCardsID { get; set; }
        public string Text { get; set; }
        public User SubCommentedByID { get; set; }
    }
}
