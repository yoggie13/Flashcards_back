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
        public User User { get; set; }
        public DeckOfCards DeckOfCards { get; set; }
        [Key]
        public int LikeID { get; set; }
    }
}
