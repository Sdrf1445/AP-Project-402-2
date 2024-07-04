using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Restaurant_Manager.Classes
{
    public class Admin
    {
        private static string username = "sadramin";
        private static string password = "12345";

        public static void AddRestaurant(string username, string password, string name, string city, ReceptionType receptionType, string address)
        {
            Restaurant restaurant = new Restaurant(username, password, name, city, receptionType, address);
            Database.Instance.Restaurants.Add(restaurant);
            Database.Instance.SaveChanges();            
        }

        public static bool CheckOldPassword(int restaurantID, string oldPassword)
        {
            var result = Database.Instance.Restaurants
                .Where(x => x.ID == restaurantID && x.Password == oldPassword)
                .First();
            if (result == null)
            {
                return false;
            }
            return true;
            
        }
        public static void ChangeRestaurantPassword(int restaurantID, string oldPasswrod, string newPassword)
        {
            Database.Instance.Restaurants
                .Where(x => x.ID == restaurantID)
                .First().Password = newPassword;
            Database.Instance.SaveChanges();   
        }

        public static void AnswerComplaint(int complaintID, string answer)
        {

            Database.Instance.Complaints
                .Where(x => x.ID == complaintID)
                .First().AddAnswer(answer);
            Database.Instance.SaveChanges();
        }

        public static List<Complaint> GetAllComplaints()
        {
            return Database.Instance.Complaints.ToList();
        }

        
        // search throw complaints 
        public static List<Complaint> SearchByUsername(string username)
        {
            return Database.Instance.Complaints
                .Where(x => x.AuthorUsername.Contains(username))
                .ToList();
        }
        public static List<Complaint> SearchByRestaurantName(string restaurantName)
        {
            return Database.Instance.Complaints
                .Where(x => Restaurant.GetNameByID(x.RestaurantID).Contains(restaurantName))
                .ToList();
        }
        public static List<Complaint> SearchByTitle(string title)
        {
            return Database.Instance.Complaints
                .Where(x => x.Title.Contains(title))
                .ToList();
        }
        public static List<Complaint> SearchByFullName(string fullName)
        {
            return Database.Instance.Complaints
                .Where(x => User.GetFullNameByUsername(x.AuthorUsername).Contains(fullName))
                .ToList();
        }
        public static List<Complaint> SearchByStatus(bool status)
        {
            return Database.Instance.Complaints
                .Where(x => x.Status == status)
                .ToList();
        }
        public static List<Complaint> LastUncheckedComplaints()
        {
            return Database.Instance.Complaints
                .Where(x => x.Status == false)
                .OrderByDescending(x => x.Date)
                .ToList();
        }



    }
}
