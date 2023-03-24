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
        //TODO:...

        //Default конструктор 
        public UserModels()
        {
            UserId = 0;
            UserName = " ";
            Password= " ";
        }

        public UserModels(int userId, string userName, string password)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
        }
    }
}
