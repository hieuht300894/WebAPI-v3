using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eCountry : Master, ICountry, IType
    {
        public string PostalCode { get; set; }
        public string LocationCode { get; set; }
        public string ZipCode { get; set; }
        public int IDCountry { get; set; }
        public string CountryCode { get ; set ; }
        public string CountryName { get ; set ; }
        public int IDType { get ; set ; }
        public string TypeCode { get ; set ; }
        public string TypeName { get ; set ; }
    }
}
