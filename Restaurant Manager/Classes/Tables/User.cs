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
        public static string CurrentUser { get; set; }


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
        }

        public static string GetFullNameByUsername(string username)
        {
            return Database.Instance.Users
                .Where(x => x.Username == username)
                .Select(x => x.FullName)
                .First();
        }
        
    }
}
