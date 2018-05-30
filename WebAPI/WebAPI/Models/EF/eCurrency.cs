using WebAPI.Models.General;

namespace WebAPI.Models.EF
{
    public class eCurrency : Master
    {
        public string CodeDigital { get; set; }
        public string Prefix { get; set; }
        public byte[] Logo { get; set; }
    }
}
