using WebAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private zModel context = null;

        public Repository()
        {
            context = new zModel();
        }

        public Repository(zModel db)
        {
            context = db;
        }

        public List<T> GetItems()
        {
            return context.Set<T>().ToList();
        }

        public async Task<List<T>> GetItemsAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T FindItem(object ID)
        {
            return context.Set<T>().Find(ID);
        }

        public async Task<T> FindItemAsync(object ID)
        {
            return await context.Set<T>().FindAsync(ID);
        }

        public void AddOrUpdate(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            context.Set<T>().AddOrUpdate(item);
        }

        public void AddOrUpdate(params T[] items)
        {
            if (items == null || items.Length == 0)
                throw new ArgumentNullException();

            context.Set<T>().AddOrUpdate(items);
        }

        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            context.Set<T>().Remove(item);
        }

        public void Remove(params T[] items)
        {
            if (items == null || items.Length == 0)
                throw new ArgumentNullException();

            context.Set<T>().RemoveRange(items);
        }
    }
}
