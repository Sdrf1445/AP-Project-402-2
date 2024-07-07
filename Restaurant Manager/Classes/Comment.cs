using Restaurant_Manager.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Restaurant_Manager.Classes
{
    public class Comment
    {
        private static int lastUserID;

        public int ID {  get; set; }
        public string AuthorUsername { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public List<Comment> Replies { get; set;} = new List<Comment>();
        public bool IsEdited { get; set; } = false;
        public int Rating { get; set; }

        public Comment(string message, string username) 
        {
            Message = message;
            AuthorUsername = username;
            Date = DateTime.Now;
        }

        public static void EditComment(string newMessage, int commentID, int foodID, int restaurantID)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            Comment comment = foods
                .Where(y => y.ID == foodID)
                .First().Comments!
                .Where(x => x.ID == commentID).First();
            comment.Message = newMessage;
            comment.Date = DateTime.Now;
            comment.IsEdited = true;
            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        public static void DeleteComment(int commentID, int foodID, int restaurantID)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            var comments = foods
                .Where(y => y.ID == foodID)
                .First().Comments!;
            var comment = comments.Where(x => x.ID == commentID).First();

            comments.Remove(comment);
            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        public static void ReplyComment(string replyMessage, int commentID, int foodID, int restaurantID)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            var comments = foods
                .Where(y => y.ID == foodID)
                .First().Comments!;
            var comment = comments.Where(x => x.ID == commentID).First();
            comment.Replies.Add(new Comment(replyMessage, User.CurrentUsername));

            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        public static int UniqueIdGenerator()
        {
            return lastUserID++;
        }




    }
}
