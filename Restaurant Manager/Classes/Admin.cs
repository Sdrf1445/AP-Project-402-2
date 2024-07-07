using Microsoft.EntityFrameworkCore;
using Restaurant_Manager.Classes.Controls;
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

        public static bool IsUserAdmin(string Username)
        {
            return username == Username;
        }
        public static bool PasswordCheck(string Password)
        {
            return password == Password;
        }

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
        public static void ChangeRestaurantPassword(int restaurantID, string newPassword)
        {
            Database.Instance.Restaurants
                .Where(x => x.ID == restaurantID)
                .First().Password = newPassword;
            Database.Instance.SaveChanges();
        }

        public static void AnswerComplaint(string answer, int complaintID)
        {
            Complaint.AddAnswer(answer, complaintID);
        }

        public static List<Complaint> GetAllComplaints()
        {
            return Database.Instance.Complaints.ToList();
        }


        // search throw complaints 
        public static List<Complaint> SearchComplaintsByUsername(string username, ComplaintStatus complaintStatus, TimeOrder timeOrder)
        {
            List<Complaint> result;
            if (complaintStatus == ComplaintStatus.NoFilter)
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => x.AuthorUsername.Contains(username)).ToList();
            }
            else
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => x.AuthorUsername.Contains(username) && x.Status == (complaintStatus == ComplaintStatus.Checked)).ToList();
            }
            if(timeOrder == TimeOrder.Ascending)
            {
                return result.OrderBy(x => x.Date).ToList();
            }
            else
            {
                return result.OrderByDescending(x => x.Date).ToList();
            }
        }
        public static List<Complaint> SearchComplaintsByRestaurantName(string restaurantName,ComplaintStatus complaintStatus, TimeOrder timeOrder)
        {
            List<Complaint> result;
            if (complaintStatus == ComplaintStatus.NoFilter)
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => Restaurant.GetNameByID(x.RestaurantID).Contains(restaurantName)).ToList();
            }
            else
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => Restaurant.GetNameByID(x.RestaurantID).Contains(restaurantName) && x.Status == (complaintStatus == ComplaintStatus.Checked)).ToList();
            }
            if(timeOrder == TimeOrder.Ascending)
            {
                return result.OrderBy(x => x.Date).ToList();
            }
            else
            {
                return result.OrderByDescending(x => x.Date).ToList();
            }
        }
        public static List<Complaint> SearchComplaintsByTitle(string title, ComplaintStatus complaintStatus, TimeOrder timeOrder)
        {
            List<Complaint> result;
            if (complaintStatus == ComplaintStatus.NoFilter)
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => x.Title.Contains(title)).ToList();
            }
            else
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => x.Title.Contains(title) && x.Status == (complaintStatus == ComplaintStatus.Checked)).ToList();
            }
            if(timeOrder == TimeOrder.Ascending)
            {
                return result.OrderBy(x => x.Date).ToList();
            }
            else
            {
                return result.OrderByDescending(x => x.Date).ToList();
            }

        }
        public static List<Complaint> SearchComplaintsByFullName(string fullName,ComplaintStatus complaintStatus,TimeOrder timeOrder)
        {
            List<Complaint> result;
            if (complaintStatus == ComplaintStatus.NoFilter)
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => User.GetFullNameByUsername(x.AuthorUsername).Contains(fullName)).ToList();
            }
            else
            {
                result = Database.Instance.Complaints.ToList()
                    .Where(x => User.GetFullNameByUsername(x.AuthorUsername).Contains(fullName) && x.Status == (complaintStatus == ComplaintStatus.Checked)).ToList();
            }
            if(timeOrder == TimeOrder.Ascending)
            {
                return result.OrderBy(x => x.Date).ToList();
            }
            else
            {
                return result.OrderByDescending(x => x.Date).ToList();
            }
        }
        public static List<Complaint> SearchComplaintsByStatus(bool status)
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

        // search throw restaurant 
        public static List<string> GetAllRestaurantCities()
        {
            return Database.Instance.Restaurants
                .Select(x => x.City)
                .Distinct()
                .ToList();
        }
        public static List<Restaurant> GetAllRestaurants()
        {
            return Database.Instance.Restaurants.ToList();
        }

        public static List<Restaurant> SearchRestaurantByName(string name)
        {
            return Database.Instance.Restaurants
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        public static List<Restaurant> SearchRestaurantByCity(string city)
        {
            return Database.Instance.Restaurants
                .Where(x => x.City == city)
                .ToList();
        }
        public static List<Restaurant> FilterRestaurants(ReceptionType type, RatingsOrder order, string city = null, string name = null)
        {
            var result = Database.Instance.Restaurants.AsQueryable();
            if (type != ReceptionType.NoFilter)
            {
                result = result.Where(x => x.ReceptionType == type);
            }
            if (name != null && name != "")
            {
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (city != null && city != "")
            {
                result = result.Where(x => x.City == city);
            }
            var list = result.ToList();
            if (order == RatingsOrder.Ascending)
            {
                return list.OrderBy(x => x.Rating).ToList();
            }
            else
            {
                return list.OrderByDescending(x => x.Rating).ToList();
            }


        }

        public static List<Restaurant> HaveUncheckedComplaints()
        {
            return Database.Instance.Restaurants
                .Where(x => x.Complaints.Any(y => y.Status == false))
                .ToList();
        }

        public static List<Restaurant> RestaurantsRatingOrderByDescending()
        {
            return Database.Instance.Restaurants
                .OrderByDescending(x => x.Rating)
                .ToList();
        }

        public static List<Restaurant> RestaurantsRatingOrderByAscending()
        {
            return Database.Instance.Restaurants
                .OrderBy(x => x.Rating)
                .ToList();
        }

        public static List<Restaurant> SearchRestaurantByReceptionType(ReceptionType receptionType)
        {
            return Database.Instance.Restaurants
                .Where(x => x.ReceptionType == receptionType)
                .ToList();
        }



    }
}
