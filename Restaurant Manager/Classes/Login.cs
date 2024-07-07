using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum UserType { CUTOMER = 0, ADMIN = 1, RESTAURANT = 2}
    public class Login
    {
        public static bool IsUsernameUnique(string username)
        {
            bool isRestaurant = Database.Instance.Restaurants
                .Any(x => x.Username == username);
            bool isUser = Database.Instance.Users
                .Any(x => x.Username == username);
            return !(isRestaurant || isUser || Admin.IsUserAdmin(username));
        }

        public static bool DoesUserExist(string username, string password)
        {
            bool isRestaurant = Database.Instance.Users
                .Any(x => x.Username == username && x.PasswordHash ==  Security.CreateMD5(password) );
            bool isUser = Database.Instance.Restaurants
                .Any(x => x.Username == username && x.Password == password);
            return isRestaurant || isUser || Admin.PasswordCheck(password);
        }

        public static UserType DeterminUserTypeAndLogin(string username, string password)
        {
            if (Database.Instance.Users.Any(x => x.Username == username))
            {
                User.CurrentUsername = username;
                return UserType.CUTOMER;
            }
            else if(Database.Instance.Restaurants.Any(x => x.Username == username))
            {
                Restaurant.CurrentRestaurantID = Database.Instance.Restaurants.Where(x => x.Username == username).First().ID;
                return UserType.RESTAURANT;
            }
            else
            {
                return UserType.ADMIN;
            }
        }
        

        public static bool IsMobilePhoneUniqe(string mobilephone)
        {
            return !Database.Instance.Users.Any(user => user.PhoneNumber == mobilephone);

        }
    }
}
