using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum ReceptionType { DELIVERY, DINEIN, BOTH }
    public class Restaurant
    {
        public int CurrentRestaurantID {  get; set; }

        [Key]
        public int ID { get; set; }
        public bool HaveReserveService { get; set; } = false; // default value
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ReceptionType ReceptionType { get; set; }

        public Restaurant(string username, string password, string name, string city, ReceptionType receptionType, string address)
        {
            Username = username;
            Password = password;
            Name = name;
            City = city;
            Address = address;
            ReceptionType = receptionType;
        }

        public static string GetNameByID(int id)
        {
            return Database.Instance.restaurants
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .First();
        }

        public double Rating()
        {
            throw new NotImplementedException();
        }

    }
}
