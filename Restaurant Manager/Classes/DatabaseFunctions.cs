using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    internal class DatabaseFunctions
    {
        public static bool IsLoginCreditionalsValid(string username,string password)
        {
            string passwordHash = Security.CreateMD5(password);
            return Database.Instance.Users.Any(user => user.Username == username && user.PasswordHash == passwordHash);
        }
        public static bool IsMobilePhoneUniqe(string mobilephone)
        {
            return !Database.Instance.Users.Any(user => user.PhoneNumber == mobilephone);
        }
        public static bool IsUserNameUniqe(string username)
        {
            return !Database.Instance.Users.Any(user => user.Username == username);
        }
    }
}
