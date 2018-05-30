using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eImportProductProviderDetail : Master, IImportProductProvider, IProductCategory, IProduct, IUnit, IWarehouse
    {
        public int IDProduct { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int IDUnit { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public int IDWarehouse { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public System.DateTime? ExpiredDate { get; set; }
        public decimal WholeQuantity { get; set; }
        public decimal RetailQuantity { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public decimal Discount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int IDProductCategory { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductCategoryName { get; set; }
        public string ImportProductProviderCode { get; set; }
        public string ImportProductProviderName { get; set; }
        public int IDImportProductProvider { get; set; }
    }
}
