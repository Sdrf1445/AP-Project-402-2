using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        [AllowNull]
        public string ImageSource { get; set; }
        public List<Comment> Comments { get; set; }

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
        public double Rating()
        {
            if (Comments == null)
            {
                return 0;
            }
            return Comments.Select(x => x.Rating)
                .Average();
        }
    }
}
