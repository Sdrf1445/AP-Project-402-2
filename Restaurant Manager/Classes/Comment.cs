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
        public Rating Rating { get; set; }

        public Comment(string message, string username) 
        {
            Message = message;
            AuthorUsername = username;
            Date = DateTime.Now;
        }

        public static int UniqueIdGenerator()
        {
            return lastUserID++;
        }

        public static double GetFoodRating(int foodID, int restaurantID)
        {
            var ratings = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods
                .Where(x => x.ID == foodID)
                .First().Ratings;
            if (ratings == null)
            {
                return -1;
            }
            return ratings.Where(x => x.Username == User.CurrentUsername)
                .Select(x => x.Value)
                .First();
        }

        




    }
}
