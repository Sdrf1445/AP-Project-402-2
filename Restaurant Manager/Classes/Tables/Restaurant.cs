using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public enum ReceptionType { DELIVERY = 0, DINEIN = 1, BOTH = 2 , NoFilter = 3}
    public enum OrderReserveBoth { RESERVE = 0, ORDER = 1, BOTH = 2}
    public enum PriceOrder { ASCENDING = 0, DESCENDING = 1 }
    public class Restaurant
    {
        public static int CurrentRestaurantID { get; set; }
        public static double MinimumRating { get; set; }

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
        
        public static void GetCurrentRestaurantByUsername(string username)
        {
            CurrentRestaurantID = Database.Instance.Restaurants
                .Where(x => x.Username == username)
                .Select(x => x.ID)
                .First();
        }

        public static List<Menu> GetAllMenus(int restaurantID)
        {
            return Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .ToList();
        }

        public static string GetNameByID(int id)
        {
            return Database.Instance.Restaurants
                .Where(x => x.ID == id)
                .Select(x => x.Name)
                .First();
        }

        public static void AddMenu(string name)
        {
            Menu menu = new Menu(name, CurrentRestaurantID);
        }
        
        public static void RemoveMenu(int menuID)
        {
            Menu menu = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First();
            Database.Instance.Menus
                .Remove(menu);
            Database.Instance.SaveChanges();
        }

        public static void AddFoodToMenu(int menuID, string name, int remaining, string ingrediants, double price)
        {
            Food newFood = new Food(menuID, remaining, name, ingrediants, price);
            var foods = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods;
            foods.Add(newFood);
            Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        public static void RemoveFoodFromMenu(int menuID, int foodID)
        {
            Food deletedFood = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods
                .Where(x => x.ID == foodID)
                .First();
            var foods = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods;
            foods.Remove(deletedFood);
            Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        public static void EditMenuInformation(int menuID, string newName)
        {
            Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Name = newName;
            Database.Instance.SaveChanges();
        }

        public static void EditFoodInformation(int menuID, int foodID, string name, string ingrediants, double price, int remaining, string? imageSource)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .First().Foods;
            var editedFood = foods
                .Where(x => x.ID == foodID)
                .First();
            editedFood.Name = name;
            editedFood.Remaining = remaining;
            editedFood.Ingredients = ingrediants;
            editedFood.Price = price;
            if (imageSource != null)
            {
                editedFood.ImageSource = imageSource;
            }

            Database.Instance.Menus
                .Where (x => x.ID == menuID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }

        // filter orders

        public static List<Order> GetAllOrders(int restaurantID)
        {
            return Database.Instance.Restaurants
                .Where(x => x.ID ==  restaurantID)
                .First().Orders;
        }


        public static (List<Order>, List<Reservation>) FilterByUsername(string username, OrderReserveBoth orderReserveBoth, PriceOrder priceOrder)
        {

            // filter reservations
            var reservations = new List<Reservation>();

            // filter orders
            var orders = Database.Instance.Restaurants
                .Where(x => x.ID == CurrentRestaurantID)
                .First().Orders
                .Where(x => x.Username == username);
            if(priceOrder == PriceOrder.ASCENDING)
            {
                orders = orders.OrderBy(x => x.SumPrice);
            }
            else
            {
                orders = orders.OrderByDescending(x => x.SumPrice);
            }

            if(orderReserveBoth == OrderReserveBoth.ORDER)
            {
                return (orders.ToList(), new List<Reservation>());
            }
            else if(orderReserveBoth == OrderReserveBoth.RESERVE)
            {
                return (new List<Order>(), reservations.ToList());
            }
            else
            {
                return (orders.ToList(), reservations.ToList());
            }
        }

        public static (List<Order>, List<Reservation>) FilterByMobileNumber(string mobileNumber, OrderReserveBoth orderReserveBoth, PriceOrder priceOrder)
        {

            // filter reservations
            var reservations = new List<Reservation>();

            // filter orders
            var orders = Database.Instance.Restaurants
                .Where(x => x.ID == CurrentRestaurantID)
                .First().Orders
                .Where(x => User.GetMobileNumberByUsername(x.Username).Contains(mobileNumber));
            if (priceOrder == PriceOrder.ASCENDING)
            {
                orders = orders.OrderBy(x => x.SumPrice);
            }
            else
            {
                orders = orders.OrderByDescending(x => x.SumPrice);
            }

            if (orderReserveBoth == OrderReserveBoth.ORDER)
            {
                return (orders.ToList(), new List<Reservation>());
            }
            else if (orderReserveBoth == OrderReserveBoth.RESERVE)
            {
                return (new List<Order>(), reservations.ToList());
            }
            else
            {
                return (orders.ToList(), reservations.ToList());
            }
        }

        public static (List<Order>, List<Reservation>) FilterByFoodName(string foodName, OrderReserveBoth orderReserveBoth, PriceOrder priceOrder)
        {

            // filter reservations
            var reservations = new List<Reservation>();

            // filter orders
            var orders = Database.Instance.Restaurants
                .Where(x => x.ID == CurrentRestaurantID)
                .First().Orders
                .Where(x => x.Foods.Any(y => y.Name.Contains(foodName)));

            if (priceOrder == PriceOrder.ASCENDING)
            {
                orders = orders.OrderBy(x => x.SumPrice);
            }
            else
            {
                orders = orders.OrderByDescending(x => x.SumPrice);
            }

            if (orderReserveBoth == OrderReserveBoth.ORDER)
            {
                return (orders.ToList(), new List<Reservation>());
            }
            else if (orderReserveBoth == OrderReserveBoth.RESERVE)
            {
                return (new List<Order>(), reservations.ToList());
            }
            else
            {
                return (orders.ToList(), reservations.ToList());
            }
        }

        public static double TotalSell((List<Order>,List<Reservation>) ordersAndReservations)
        {
            var result = ordersAndReservations.Item1.Select(x => x.SumPrice)
                .Sum();
            
            // add reservation sum price to result 

            return result;
        }

        public static double OnlinePaymentPercentage((List<Order>, List<Reservation>) ordersAndReservations)
        {
            var orderPercentage = (ordersAndReservations.Item1
                .Where(x => x.PaymentMethod == PaymentMethod.ONLINE)
                .Count() / ordersAndReservations.Item1.Count()) * 100;

            // reservation percentage

            return orderPercentage;

        }


        public static bool CanEnableReservationService()
        {
            var restaurant = Database.Instance.Restaurants
                .Where(x => x.ID == CurrentRestaurantID)
                .First();

            return restaurant.Rating > Restaurant.MinimumRating;

        }
        public static bool EnableReservationService()
        {
            if (CanEnableReservationService())
            {
                Database.Instance.Restaurants
                    .Where(x => x.ID == CurrentRestaurantID)
                    .First().HaveReserveService = true;
                Database.Instance.SaveChanges();
                return true;
            }
            else
            {
                Database.Instance.Restaurants
                    .Where(x => x.ID == CurrentRestaurantID)
                    .First().HaveReserveService = false;
                Database.Instance.SaveChanges();
                return false;
            }
        }

        public static void DisableReservationService()
        {
            Database.Instance.Restaurants
                .Where(x => x.ID == CurrentRestaurantID)
                .First().HaveReserveService = false;
            Database.Instance.SaveChanges();
        }
        public static Restaurant GetRestaurantById(int restaurantID)
        {
            return Database.Instance.Restaurants.First(x => x.ID==restaurantID);
        } 
    }
}
