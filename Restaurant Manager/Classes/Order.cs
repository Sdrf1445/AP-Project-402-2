using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Order
    {
        public int ID {  get; set; }
        public List<Food> Foods { get; set; }
        public DateTime Time { get; set; }
        public Comment Comment { get; set; }
        public Rating Rating { get; set; }

    }
}
