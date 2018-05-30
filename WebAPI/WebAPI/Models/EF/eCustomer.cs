using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eCustomer : Master, ICountry, IGender
    {
        public System.DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public int IDCountry { get ; set ; }
        public string CountryCode { get ; set ; }
        public string CountryName { get ; set ; }
        public int IDGender { get ; set ; }
        public string GenderCode { get ; set ; }
        public string GenderName { get ; set ; }
    }
}
