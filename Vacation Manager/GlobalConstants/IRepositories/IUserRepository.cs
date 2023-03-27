using Microsoft.AspNetCore.Identity;
using Vacation_Manager.Areas.Identity.Data;
using Vacation_Manager.Models;

namespace Vacation_Manager.GlobalConstants.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();
    }
}
