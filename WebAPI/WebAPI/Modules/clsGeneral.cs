using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class clsGeneral
    {
        public static string connectionString { get; set; }
        public static int pageSize { get; private set; } = 10;
    }
}