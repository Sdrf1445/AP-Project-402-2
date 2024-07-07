using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Windows.Media.Imaging;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Manager.Classes
{
    public class Food
    {
        private static int lastUserID = 0;

        public int ID { get; set; }
        public int MenuID { get; set; }
        public int Remaining { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string? ImageSource { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Rating>? Ratings { get; set; }
        // fix this part if you could
        private int? numberOrdered;
        public int? NumberOrdered
        {
            get
            {
                return numberOrdered;
            }
            set
            {
                if (value > Remaining || value < 0)
                {
                    throw new Exception("There is not that much food remaining!");
                }
                numberOrdered = value;
                
            }
        }

        public int Rating
        {
            get
            {
                if (Ratings == null)
                {
                    return 0;
                }
                double average = Ratings.Select(x => x.Value).Average();
                return (int)Math.Round(average);
            }
        }

        public Food(int menuID, int remaining, string name, string ingredients, double price)
        {
            MenuID = menuID;
            Remaining = remaining;
            Name = name;
            Ingredients = ingredients;
            Comments = new List<Comment>();
            Price = price;
            ID = UniqueIdGenerator();
        }
        public Food(int menuID, int remaining, string name, string? imageSource, string ingredients, double price)
        {
            MenuID = menuID;
            Remaining = remaining;
            Name = name;
            ImageSource = imageSource;
            Ingredients = ingredients;
            Comments = new List<Comment>();
            Price = price;
            ID = UniqueIdGenerator();
        }
        public static int UniqueIdGenerator()
        {
            return lastUserID++;
        }

        

        
        
        public static void UploadImage(int menuID, int foodID, string imageSource)
        {
            int restaurantID = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .Select(x => x.RestaurantID)
                .First();
            string exeDirectory = $"./Images/{restaurantID}/{menuID}/{foodID}.data";
            FileInfo file = new FileInfo(exeDirectory);
            file.Directory.Create();
            File.Copy(imageSource, file.FullName );
        }

        public static BitmapImage ReadImage(int menuID, int foodID)
        {
            int restaurantID = Database.Instance.Menus
                .Where(x => x.ID == menuID)
                .Select(x => x.RestaurantID)
                .First();
            string filePath = $"./Images/{restaurantID}/{menuID}/{foodID}.data";
            Uri defaultPath = new Uri("./Images/DefaultFood/image.png");
            if (!File.Exists(filePath))
            {
                return new BitmapImage(defaultPath);
            }

            return new BitmapImage(new Uri(filePath));
        }

        public static void AddComment(string message, int foodID, int restaurantID)
        {
            Comment newComment = new Comment(message, User.CurrentUsername);

            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;

            
            var comments = foods.Where(x => x.ID == foodID).First().Comments;
            if (comments == null)
            {
                comments = new List<Comment>();
            }
            comments.Add(newComment);

            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
        }
        public static void AddRating(double rating, int foodID, int restaurantID)
        {
            var foods = Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods;

            var food = foods.Where(x => x.ID == foodID).First();
            if (food.Ratings == null)
            {
                food.Ratings = [new Rating(User.CurrentUsername, rating)];
            }
            else
            {
                food.Ratings.Add(new Classes.Rating(User.CurrentUsername, rating));
            }

            Database.Instance.Menus
                .Where(x => x.RestaurantID == restaurantID)
                .First().Foods = foods;
            Database.Instance.SaveChanges();
            

        }
    }
}
