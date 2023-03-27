using Vacation_Manager.GlobalConstants.Repositories;

namespace Vacation_Manager.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository user)
        {
            User = user;
        }

        public IUserRepository User { get; }
    }
}
