using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public User(string firstName, string lastName, string userName, string password, string email, string mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Username = userName;
            MobileNumber = mobileNumber;
        }
    }
}
