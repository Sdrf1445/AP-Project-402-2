using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Database : DbContext
    {
        public static Database Instance = new Database();
        string dbPath = "";
        public DbSet<User> Users {  get; set; } 
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public Database()
        {
            var folderPath = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            //dbPath = directory.Parent!.Parent!.Parent!.GetDirectories().Where(x => x.Name == "Data").First().GetFiles().First(x => x.Name.EndsWith(".db")).FullName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Data Source={dbPath}");
            optionsBuilder.UseSqlite(@"Data Source=D:\RES\Restaurant Manager\Data\database.db");
        }
    } 
}
