using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public partial class xAccount : Master, IPersonnel, IPermissionCategory
    {
        public string IPAddress { get; set; } = string.Empty;
        public int IDPersonnel { get; set; }
        public string PersonnelCode { get; set; }
        public string PersonnelName { get; set; }
        public int IDPermissionCategory { get; set; }
        public string PermissionCategoryCode { get; set; }
        public string PermissionCategoryName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEnable { get; set; }
    }
}
