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
        [Key]
        public int CommentID { get; set; }
        public User UserID { get; set; }
        public DeckOfCards DeckOfCardsID { get; set; }
        public string Text { get; set; }
        public List<SubComment> SubComments { get; set; }
    }
}
