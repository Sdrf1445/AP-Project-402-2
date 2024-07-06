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

namespace Restaurant_Manager.Classes
{
    public class Food
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int Remaining { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string? ImageSource { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }

        public Food(int menuID, int remaining, string name, string ingredients, double price)
        {
            MenuID = menuID;
            Remaining = remaining;
            Name = name;
            Ingredients = ingredients;
            Comments = new List<Comment>();
            Price = price;
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
        }
        public static int UniqueIdGenerator()
        {
            throw new NotImplementedException();
        }
        public double Rating()
        {
            throw new NotImplementedException();
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

        public static void AddComment()
        {
            throw new NotImplementedException();
        }
    }
}
