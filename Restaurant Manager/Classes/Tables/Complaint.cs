using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Complaint
    {
        [Key]
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorUsername { get; set; }
        public bool Status { get; set; } = false;
        public string? AnswerJson {  get; set; }
        [NotMapped]
        public Comment? Answer { 
            get
            {
                if(AnswerJson == null)
                {
                    return null;
                }
                return JsonSerializer.Deserialize<Comment>(AnswerJson);
            }
            set
            {
                if(value == null)
                {
                    AnswerJson = null;
                }
                else
                {
                    AnswerJson = JsonSerializer.Serialize(value);
                }

            }
        }

        public Complaint(int restaurantID, string title, string description, string authorUsername)
        {
            RestaurantID = restaurantID;
            Title = title;
            Description = description;
            AuthorUsername = authorUsername;
            Date = DateTime.Now;
        }

        public void AddAnswer(string answer)
        {
            Status = true;
            Answer = new Comment(answer, AuthorUsername);
        }
    }
}
