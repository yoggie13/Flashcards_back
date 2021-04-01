using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace REST.Model
{
    public class DeckOfCards 
    {
        [Key]
        public int DeckOfCardsID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Subject Subject { get; set; }
        public List<Card> Cards { get; set; }
        public List<Comment> Comments { get; set; }
        [JsonIgnore]
        public List<Like> Likes { get; set; }
        [NotMapped]
        public int NumberOfLikes { get; set; }
        [NotMapped]
        public bool LikedByUser { get; set; }



    }
}
