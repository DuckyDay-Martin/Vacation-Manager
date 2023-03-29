using Microsoft.AspNetCore.Identity;

namespace Vacation_Manager.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ApplicationUser(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        
    }
}
