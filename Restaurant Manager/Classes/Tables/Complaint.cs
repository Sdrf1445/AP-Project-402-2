using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Complaint
    {
        [Key]
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorUsername { get; set; }
        public bool Status { get; set; }
        public Comment Reply { get; set; }
    }
}
