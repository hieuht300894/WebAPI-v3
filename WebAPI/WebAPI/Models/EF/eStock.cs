using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eStock : Master, IProductCategory, IProduct, IUnit, IWarehouse
    {
        public System.DateTime Date { get; set; }
        public int IDProduct { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int IDProductCategory { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductCategoryName { get; set; }
        public int IDUnit { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public int IDWarehouse { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public System.DateTime? ExpiredDate { get; set; }
        public int IDType { get; set; }
        public int IDMaster { get; set; }
        public int IDDetail { get; set; }
        public decimal WholeQuantity { get; set; }
        public decimal RetailQuantity { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
