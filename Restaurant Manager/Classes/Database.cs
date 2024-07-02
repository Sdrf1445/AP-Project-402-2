using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Database : DbContext
    {
        public static Database Instance = new Database();
        string dbPath = "";
        public DbSet<User> users {  get; set; }
        public Database()
        {
            var folderPath = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            dbPath = directory.Parent!.Parent!.Parent!.GetDirectories().Where(x => x.Name == "Data").First().GetFiles().First(x => x.Name.EndsWith(".db")).FullName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Name { get;set; }
        public string LastName { get;set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
