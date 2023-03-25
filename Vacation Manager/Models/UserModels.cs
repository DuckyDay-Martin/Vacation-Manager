using System.ComponentModel.DataAnnotations;

namespace Vacation_Manager.Models
{
    public class UserModels
    {
        int UserId { get; set; }

        [Required]
        string UserName { get; set; }

        [Required]
        public string Password { get; set; }


        public string Name { get; set; }


        public string LastName { get; set; }


        public string Role { get; set; }


        public string Team { get; set; }


        //Default конструктор 
        public UserModels()
        {
            UserId = 0;
            UserName = " ";
            Password= " ";
            Name = " ";
            LastName = " ";
            Role = "Unsigned";
            Team = " ";
        }

        public UserModels(int userId, string userName, string password, string name, string lastName, string role, string team)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Name = name;
            LastName = lastName;
            Role = role;
            Team = team;
        }
    }
}
