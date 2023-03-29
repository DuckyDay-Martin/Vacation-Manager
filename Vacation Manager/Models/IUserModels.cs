namespace Vacation_Manager.Models
{
    public interface IUserModels
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Role { get; set; }
        string Team { get; set; }
        int UserId { get; set; }
    }
}