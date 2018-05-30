using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.General
{
    public class Detail
    {
        public Int32 KeyID { get; set; } = AutoGenerateID.KeyID;
        public String Note { get; set; } = string.Empty;
        public Int32 Status { get; set; } = 1;
        public Boolean IsDefault { get; set; }
    }
}
