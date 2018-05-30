using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class xPermissionDetail : Master, IPermissionCategory, IPermission
    {
        public int IDPermissionCategory { get ; set ; }
        public string PermissionCategoryCode { get ; set ; }
        public string PermissionCategoryName { get ; set ; }
        public int IDPermission { get ; set ; }
        public string Controller { get ; set ; }
        public string Action { get ; set ; }
        public string Method { get ; set ; }
        public string Template { get ; set ; }
        public string Path { get ; set ; }
    }
}
