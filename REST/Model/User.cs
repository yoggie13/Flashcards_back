﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace REST.Model
{
    [DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Role Role { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<SubComment> SubComments { get; set; }
        public DateTime? DateRegistered { get; set; }


    }
}
