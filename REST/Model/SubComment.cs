using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class SubComment
    {
        [Key, Column(Order = 1)]
        public int SubCommentID { get; set; }
        [Key, Column(Order = 0)]
        public Comment CommentID { get; set; }
        public string Text { get; set; }
        [Key, Column(Order = 2)]
        public User SubCommentedByID { get; set; }
    }
}
