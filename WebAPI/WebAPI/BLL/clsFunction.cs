using Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.BLL
{
    public static class clsFunction
    {
        public static IEnumerable<T> GetItems<T>(this Repository<T> repository, int page) where T : class, new()
        {
            return repository.GetItems().ToPagedList(page, Define.Instance.PageSize);
        }

        public static async Task<IEnumerable<T>> GetItemsAsync<T>(this Repository<T> repository, int page) where T : class, new()
        {
            List<T> lstItems = await repository.GetItemsAsync();
            return lstItems.ToPagedList(page, Define.Instance.PageSize);
        }
    }
}