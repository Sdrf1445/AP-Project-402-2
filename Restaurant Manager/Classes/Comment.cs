using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Restaurant_Manager.Classes
{
    public class Comment
    {
        public int ID {  get; set; }
        public string AuthorUsername { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public List<Comment> Replies { get; set;} = new List<Comment>();
        public bool IsEdited { get; set; } = false;

        public Comment(string message, string username) 
        {
            Message = message;
            AuthorUsername = username;
            Date = DateTime.Now;
        }
        


    }
}
