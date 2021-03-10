using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Key]
        public User UserID { get; set; }
        [Key]
        public DeckOfCards DeckOfCardsID { get; set; }
        public string Text { get; set; }

    }
}
