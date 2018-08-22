using WebAPI.Models;
using WebAPI.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.BLL
{
    public static class clsUnit
    {
        public static IEnumerable<eUnit> GetAllWithTitle(this Repository<eUnit> repository, string msg)
        {
            List<eUnit> lstItems = repository.GetItems();
            lstItems.Insert(0, new eUnit() { KeyID = 0, Name = msg });
            return lstItems;
        }
    }
}