namespace Vacation_Manager.GlobalConstants.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
    }
}
