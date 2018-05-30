using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Model;

namespace WebAPI
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private zModel Context;

        public RepositoryCollection(zModel db)
        {
            this.Context = db;
        }

        public Repository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(Context);
        }
    }
}