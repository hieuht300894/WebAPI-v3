using System.Threading.Tasks;

namespace WebAPI
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}