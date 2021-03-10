using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class SubComment
    {
        [Key]
        public int SubCommentID { get; set; }
        [Key]
        public Comment CommentID { get; set; }
        public string Text { get; set; }
        [Key]
        public User SubCommentedByID { get; set; }
    }
}
