using WebAPI.Models.General;
using WebAPI.Models.Interface;
using System;

namespace WebAPI.Models.EF
{
    public class eOpeningStock : Master, IProductCategory, IProduct, IUnit, IWarehouse
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
        public System.DateTime Date { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public decimal TotalQuantity { get; set; }
        public int IDProductCategory { get ; set ; }
        public string ProductCategoryCode { get ; set ; }
        public string ProductCategoryName { get ; set ; }
    }
}
