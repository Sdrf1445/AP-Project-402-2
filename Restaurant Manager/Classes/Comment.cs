using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Comment
    {
        public int ID {  get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public List<Comment> Replies { get; set;}
        public double Rating { get; set; }
        public bool IsEdited { get; set; }


    }
}
