﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public List<Like> Likes { get; set; }
        public int NumberOfLikes { get; set; }
        public bool LikedByUser { get; set; }



    }
}
