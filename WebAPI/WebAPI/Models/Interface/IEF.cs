using System;

namespace WebAPI.Models.Interface
{
    public interface IEF
    {
        Int32 KeyID { get; set; }
        String Note { get; set; }
        Int32 Status { get; set; }
        Boolean IsDefault { get; set; }
    }
    public interface IMaster
    {
        String Code { get; set; }
        String Name { get; set; }
        DateTime CreatedDate { get; set; }
        Int32 CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        Int32? ModifiedBy { get; set; }
    }
    public interface IProduct
    {
        Int32 IDProduct { get; set; }
        String ProductCode { get; set; }
        String ProductName { get; set; }
    }
    public interface IUnit
    {
        Int32 IDUnit { get; set; }
        String UnitCode { get; set; }
        String UnitName { get; set; }
    }
    public interface ICustomer
    {
        Int32 IDCustomer { get; set; }
        String CustomerCode { get; set; }
        String CustomerName { get; set; }
    }
    public interface IWarehouse
    {
        Int32 IDWarehouse { get; set; }
        String WarehouseCode { get; set; }
        String WarehouseName { get; set; }
    }
    public interface IProvider
    {
        Int32 IDProvider { get; set; }
        String ProviderCode { get; set; }
        String ProviderName { get; set; }
    }
    public interface IProductCategory
    {
        Int32 IDProductCategory { get; set; }
        String ProductCategoryCode { get; set; }
        String ProductCategoryName { get; set; }
    }
    public interface ICurrency
    {
        Int32 IDCurrency { get; set; }
        String CurrencyCode { get; set; }
        String CurrencyName { get; set; }
    }
    public interface ICountry
    {
        Int32 IDCountry { get; set; }
        String CountryCode { get; set; }
        String CountryName { get; set; }
    }
    public interface IAccount
    {
        Int32 IDAccount { get; set; }
        String AccountCode { get; set; }
        String AccountName { get; set; }
    }
    public interface IAgency
    {
        Int32 IDAgency { get; set; }
        String AgencyCode { get; set; }
        String AgencyName { get; set; }
    }
    public interface IFunction
    {
        Int32 IDFunction { get; set; }
        String FunctionCode { get; set; }
        String FunctionName { get; set; }
    }
    public interface IPermission
    {
        Int32 IDPermission { get; set; }
        String Controller { get; set; }
        String Action { get; set; }
        String Method { get; set; }
        String Template { get; set; }
        String Path { get; set; }
    }
    public interface IPermissionCategory
    {
        Int32 IDPermissionCategory { get; set; }
        String PermissionCategoryCode { get; set; }
        String PermissionCategoryName { get; set; }
    }
    public interface IPersonnel
    {
        Int32 IDPersonnel { get; set; }
        String PersonnelCode { get; set; }
        String PersonnelName { get; set; }
    }
    public interface IPermissionDetail
    {
        Int32 IDPermissionDetail { get; set; }
        String PermissionDetailCode { get; set; }
        String PermissionDetailName { get; set; }
    }
    public interface IImportProductProvider
    {
        Int32 IDImportProductProvider { get; set; }
        String ImportProductProviderCode { get; set; }
        String ImportProductProviderName { get; set; }
    }
    public interface IType
    {
        Int32 IDType { get; set; }
        String TypeCode { get; set; }
        String TypeName { get; set; }
    }
    public interface IGender
    {
        Int32 IDGender { get; set; }
        String GenderCode { get; set; }
        String GenderName { get; set; }
    }
}
