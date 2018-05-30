using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public interface IRepositoryCollection
    {
        Repository<T> GetRepository<T>() where T : class, new();
    }
}