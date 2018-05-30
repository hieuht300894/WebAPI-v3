using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetItems();
        Task<List<T>> GetItemsAsync();
        T FindItem(object ID);
        Task<T> FindItemAsync(object ID);
        void AddOrUpdate(T Item);
        void AddOrUpdate(params T[] Items);
        void Remove(T Item);
        void Remove(params T[] Items);
    }
}
