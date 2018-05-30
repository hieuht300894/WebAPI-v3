using WebAPI.Models.General;
using WebAPI.Models.Interface;
using System.Collections.Generic;

namespace WebAPI.Models.EF
{
    public class eImportProductProvider : Master, IProvider
    {
        public string CodeNo { get; set; }
        public System.DateTime ImportDate { get; set; }
        public int IDProvider { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public decimal Discount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalRemain { get; set; }
        public decimal TotalDebt { get; set; }
        public virtual ICollection<eImportProductProviderDetail> eImportProductProviderDetails { get; set; } = new HashSet<eImportProductProviderDetail>();
    }
}
