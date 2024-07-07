using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum PaymentMethod { ONLINE = 0, CASH = 1 }
    public class Order
    {
        private static int lastUserID;

        public int ID {  get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
        public DateTime Time { get; set; }
        public Comment? Comment { get; set; }
        public Rating? Rating { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double SumPrice
        {
            get
            {
                if (Foods.Count == 0) return 0;
                return Foods.Select(x => x.Price * (double)x.NumberOrdered!).Sum();
            }
        }


        public Order(string username, PaymentMethod paymentMethod = PaymentMethod.CASH)
        {
            Username = username;
            PaymentMethod = paymentMethod;
            Time = DateTime.Now;
            Code = GenerateUniqueCode();
        }

        public static int UniqueIdGenerator()
        {
            return lastUserID++;
        }

        public string GenerateUniqueCode()
        {
            string input = Time.ToString("ss,mm,HH,dd,MM,yyyy") + Username;
            return Security.CreateMD5(input);
        }

        public static bool AddComment(string message, int orderID) // Can add comment or not ?? (there is already a comment: false)
        {
            var orders = Database.Instance.Users
                .Where(x => x.Username == User.CurrentUsername)
                .First().Orders;

            var order = orders.Where(x => x.ID == orderID).First();
            if (order.Comment != null)
            {
                return false;
            }

            order.Comment = new Comment(message, User.CurrentUsername);

            Database.Instance.Users
                .Where(x => x.Username == User.CurrentUsername)
                .First().Orders = orders;
            Database.Instance.SaveChanges();

            return true;
        }

        public static void AddRating(double rating, int orderID)
        {
            var orders = Database.Instance.Users
                .Where(x => x.Username == User.CurrentUsername)
                .First().Orders;
            var order = orders
                .Where(x => x.ID == orderID)
                .First();
            if (order.Rating == null)
            {
                order.Rating = new Rating(User.CurrentUsername, rating);
            }
            else
            {
                Rating tmp = new Rating(User.CurrentUsername, rating);
                order.Rating = tmp;
            }

            Database.Instance.Users
                .Where(x => x.Username == User.CurrentUsername)
                .First().Orders = orders;
            Database.Instance.SaveChanges();
        }







    }
}
