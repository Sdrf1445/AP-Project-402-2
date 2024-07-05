using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum ReceptionType { DELIVERY = 0, DINEIN = 1, BOTH = 2 }
    public class Restaurant
    {
        public int CurrentRestaurantID { get; set; }

        [Key]
        public int ID { get; set; }
        public bool HaveReserveService { get; set; } = false; // default value
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ReceptionType ReceptionType { get; set; }
        [NotMapped]
        public double Rating { get; set; }


        public string OrdersJson { get; set; }
        public string ComplaintsJson {  get; set; }
        [NotMapped]
        public List<Order> Orders
        {
            get
            {
                if (OrdersJson == null)
                {
                    return new List<Order>();
                }
                return JsonSerializer.Deserialize<List<Order>>(OrdersJson)!;
            }
            set
            {
                OrdersJson = JsonSerializer.Serialize(value);
            }
        }
        [NotMapped]
        public List<Complaint> Complaints
        {
            get
            {
                if (ComplaintsJson == null)
                {
                    return new List<Complaint>();
                }
                return JsonSerializer.Deserialize<List<Complaint>>(ComplaintsJson)!;
            }
            set
            {
                ComplaintsJson = JsonSerializer.Serialize(value);
            }
        }

        public Restaurant(string username, string password, string name, string city, ReceptionType receptionType, string address)
        {
            Username = username;
            Password = password;
            Name = name;
            City = city;
            Address = address;
            ReceptionType = receptionType;
            Orders = new List<Order>();
            Complaints = new List<Complaint>();
        }

        public static string GetNameByID(int id)
        {
            return Database.Instance.Restaurants
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .First();
        }

        

    }
}
