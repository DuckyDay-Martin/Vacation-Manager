using Microsoft.AspNetCore.Identity;
using Vacation_Manager.Areas.Identity.Data;
using Vacation_Manager.Data;
using Vacation_Manager.GlobalConstants.Repositories;


namespace Vacation_Manager.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()//Repository-то връща всички потребители
        {
            return _context.Users.ToList();
        }
    }
}
