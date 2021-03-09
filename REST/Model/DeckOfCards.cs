using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class DeckOfCards 
    {
        public int DeckOfCardsID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public User UserID { get; set; }
        public Subject SubjectID { get; set; }

       
    }
}
