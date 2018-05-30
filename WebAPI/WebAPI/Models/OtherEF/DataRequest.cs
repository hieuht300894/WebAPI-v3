using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.OtherEF
{
    public class DataRequest<T> where T : class, new()
    {
        public T OldData { get; set; }
        public T NewData { get; set; }
        public int Status { get; set; }
    }
}