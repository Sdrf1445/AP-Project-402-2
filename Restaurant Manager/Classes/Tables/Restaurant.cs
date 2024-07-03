using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public enum ReceptionType { DELIVERY, DINEIN, BOTH }
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }
        public bool HaveReserveService { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ReceptionType ReceptionType { get; set; }


        public double Rating()
        {
            throw new NotImplementedException();
        }

    }
}
