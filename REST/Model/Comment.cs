using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Comment
    {
        [Key, Column(Order = 2)]
        public int CommentID { get; set; }
        [Key, Column(Order = 1)]
        public User UserID { get; set; }
        [Key, Column(Order = 0)]
        public DeckOfCards DeckOfCardsID { get; set; }
        public string Text { get; set; }
        public List<SubComment> SubComments { get; set; }
    }
}
