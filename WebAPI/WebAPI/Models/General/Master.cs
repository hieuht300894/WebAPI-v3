using WebAPI.Models.Interface;
using System;

namespace WebAPI.Models.General
{
    public class Master : IEF, IMaster
    {
        public Int32 KeyID { get; set; } = AutoGenerateID.KeyID;
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public bool IsDefault { get; set; }
    }
}
