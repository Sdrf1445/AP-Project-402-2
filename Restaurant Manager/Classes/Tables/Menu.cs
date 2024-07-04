using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string FoodsJson { get; set; }
        [NotMapped]
        public List<Food> Foods
        {
            get
            {
                if (FoodsJson == null)
                {
                    return new List<Food>();
                }
                return JsonSerializer.Deserialize<List<Food>>(FoodsJson!)!;
            }
            set
            {
                FoodsJson = JsonSerializer.Serialize(value);
            }

        }
    }
}
