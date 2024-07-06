using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum PaymentMethod { ONLINE = 0, CASH = 1 }
    public class Order
    {
        public int ID {  get; set; }
        public string Username { get; set; }
        public List<Food> Foods { get; set; }
        public DateTime Time { get; set; }
        public Comment? Comment { get; set; }
        public Rating Rating { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double SumPrice
        {
            get
            {
                return Foods.Select(x => x.Price).Sum();
            }
        }
        

    }
}
