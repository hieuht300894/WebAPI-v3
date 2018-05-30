using WebAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI
{
    public class UnitOfWork : IUnitOfWork, IRepositoryCollection, IDisposable
    {
        private Dictionary<string, object> repositories;
        private bool disposed;
        private zModel context;

        public UnitOfWork()
        {
            context = new zModel();
        }

        public UnitOfWork(zModel db)
        {
            context = db;
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void CommitTransaction()
        {
            if (context.Database.CurrentTransaction != null)
                context.Database.CurrentTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (context.Database.CurrentTransaction != null)
                context.Database.CurrentTransaction.Rollback();
        }

        public Repository<T> GetRepository<T>() where T : class, new()
        {
            if (repositories == null)
                repositories = new Dictionary<string, object>();

            string type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
    }
}