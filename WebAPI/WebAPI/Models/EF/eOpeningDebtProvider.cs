using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eOpeningDebtProvider : Master, IProvider
    {
        public int IDProvider { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public System.DateTime DateFrom { get; set; }
        public System.DateTime DateTo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
