﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class SubComment
    {
        [Key]
        public int SubCommentID { get; set; }
        public Comment Comment { get; set; }
        public string Text { get; set; }
        public User SubCommentedBy { get; set; }
    }
}
