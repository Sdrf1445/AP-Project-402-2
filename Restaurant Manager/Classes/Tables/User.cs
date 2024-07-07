using Restaurant_Manager.Classes.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum Gender { MALE, FEMALE}
    public class User
    {
        public static string CurrentUsername { get; set; }
        public static Order Cart { get; set; } = new Order(CurrentUsername!);

        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return Name.Trim() + " " + LastName.Trim();
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? PostalCode { get; set; }
        public Gender? Gender { get; set; }
        public string OrdersJson { get; set; }
        [NotMapped]
        public List<Order> Orders
        {
            get
            {
                if (OrdersJson == null)
                {
                    return new List<Order>();
                }
                return JsonSerializer.Deserialize<List<Order>>(OrdersJson!)!;
            }
            set
            {
                OrdersJson = JsonSerializer.Serialize(value);
            }
        }
       

        public User(string username, string name, string lastName, string phoneNumber, string email)
        {
            Username = username;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = "";
            Orders = new List<Order>();
        }

        public static string GetFullNameByUsername(string username)
        {
            return Database.Instance.Users
                .Where(x => x.Username == username)
                .Select(x => x.FullName)
                .First();
        }

        public static string GetMobileNumberByUsername(string username)
        {
            return Database.Instance.Users
                .Where(x => x.Username == username)
                .Select(x => x.PhoneNumber)
                .First();
        }

        public static string GetEmailByUsername(string username)
        {
            return Database.Instance.Users
                .Where(x => x.Username == username)
                .Select(x => x.Email)
                .First();
        }

        public static User GetCurrentUSer()
        {
            return Database.Instance.Users
                .Where(x => x.Username == CurrentUsername)
                .First();
        }

        

        public static void EditUserInfo(Gender? gender, int? postalCode, string email)
        {
            var user = Database.Instance.Users
                .Where(x => x.Username == CurrentUsername)
                .First();
            user.Gender = gender;
            user.PostalCode = postalCode;
            user.Email = email;
            Database.Instance.SaveChanges();
        }

        // filter restaurants
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


        

        public static List<Complaint> GetAllComplaints()
        {
            return Database.Instance.Complaints
                .Where(x => x.AuthorUsername == CurrentUsername)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
        

        public static bool AddToCart(int foodID, int restaurantID) // can food be added to cart(is there anything remaining)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            var food = foods.Where(x => x.ID == foodID).First();
            if (Cart == null)
            {
                Cart = new Order(CurrentUsername);
            }
            try
            {
                food.NumberOrdered = 1;
            }
            catch
            {
                return false;
            }
            
            Cart.Foods.Add(food);

            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;

            Database.Instance.SaveChanges();
            return true;

        }

        public static void PayOrder(PaymentMethod paymentMethod, int restaurantID)
        {
            Cart.PaymentMethod = paymentMethod;
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            foreach(var food in Cart.Foods)
            {
                food.Remaining -= (int)food.NumberOrdered!;
                food.NumberOrdered = 0;
            }

            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;

            string fullName = GetFullNameByUsername(CurrentUsername);
            string userEmail = GetEmailByUsername(CurrentUsername);
            string emailText = $"hey {fullName}\n" +
                $"your order code is {Cart.Code}\n" +
                $"total price: {Cart.SumPrice}";
            Classes.Email.SendPaymentEmail(userEmail, fullName, emailText);
        }

        

        public static bool UpdateNumberOfFoodOrdered(int foodID, int number, int restaurantID) // can food be added to cart(is there anything remaining)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;
            var food = foods.Where(x => x.ID == foodID).First();
            try
            {
                food.NumberOrdered = number;
            }
            catch
            {
                return false;
            }
            
            return true;
        }



    }
}
