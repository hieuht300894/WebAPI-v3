using WebAPI.Models.General;

namespace WebAPI.Models.EF
{
    public partial class xPermission : Master
    {
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
