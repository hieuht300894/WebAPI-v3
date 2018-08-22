using WebAPI.Models;
using WebAPI.Models.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using Common;

namespace WebAPI.Models.Model
{
    public class zModel : DbContext
    {
        /*
         * Add-Migration db1 -context zModel
         * Update-Database -context zModel
         * Remove-Migration -context zModel
         */

        public DbSet<eProduct> eProducts { get; set; }
        public  DbSet<eDisplay> eDisplays { get; set; }
        public  DbSet<eExchangeUnit> eExchangeUnits { get; set; }
        public  DbSet<eExchangeCurrency> eExchangeCurrencies { get; set; }
        public  DbSet<xAccount> xAccounts { get; set; }
        public  DbSet<xAgency> xAgencies { get; set; }
        public  DbSet<xPersonnel> xPersonnels { get; set; }
        public  DbSet<xConfiguration> xConfigurations { get; set; }
        public  DbSet<xDisplay> xDisplays { get; set; }
        public  DbSet<xPermissionCategory> xPermissionCategories { get; set; }
        public  DbSet<xLanguage> xLanguages { get; set; }
        public  DbSet<xPermission> xPermissions { get; set; }
        public  DbSet<xPermissionDetail> xPermissionDetails { get; set; }
        public  DbSet<xHistory> xHistories { get; set; }
        public  DbSet<eUnit> eUnits { get; set; }
        public  DbSet<eCustomer> eCustomers { get; set; }
        public  DbSet<eWarehouse> eWarehouses { get; set; }
        public  DbSet<eProvider> eProviders { get; set; }
        public  DbSet<eUnitCategory> eUnitCategories { get; set; }
        public  DbSet<eCustomerCategory> eCustomerCategories { get; set; }
        public  DbSet<eProviderCategory> eProviderCategories { get; set; }
        public  DbSet<eProductCategory> eProductCategories { get; set; }
        public  DbSet<eCurrency> eCurrencies { get; set; }
        public  DbSet<eCountry> eCountries { get; set; }
        public  DbSet<eOpeningStock> eOpeningStocks { get; set; }
        public  DbSet<eOpeningDebtCustomer> eOpeningDebtCustomers { get; set; }
        public  DbSet<eOpeningDebtProvider> eOpeningDebtProviders { get; set; }
        public  DbSet<eDebtProvider> eDebtProviders { get; set; }
        public  DbSet<eImportProductProvider> eImportProductProviders { get; set; }
        public  DbSet<eImportProductProviderDetail> eImportProductProviderDetails { get; set; }
        public  DbSet<eStock> eStocks { get; set; }
        public  DbSet<eType> eTypes { get; set; }
        public  DbSet<eConfigurationCode> eConfigurationCodes { get; set; }


        public zModel() : base(Define.Instance.ConnectionString ?? "ConnectionDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region PrimaryKey
            modelBuilder.Entity<eDisplay>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eExchangeCurrency>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eExchangeUnit>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xAccount>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xAccount>().Property(x => x.KeyID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            modelBuilder.Entity<xAgency>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xPersonnel>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xConfiguration>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xDisplay>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xPermissionCategory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xLanguage>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xPermission>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xPermissionDetail>().HasKey(x => x.KeyID);
            modelBuilder.Entity<xHistory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eUnit>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCustomer>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eWarehouse>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eProvider>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eUnitCategory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCustomerCategory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eProviderCategory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eProductCategory>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCurrency>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eCountry>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eProduct>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eOpeningStock>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eOpeningDebtCustomer>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eOpeningDebtProvider>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eDebtProvider>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eImportProductProvider>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eImportProductProviderDetail>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eStock>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eConfigurationCode>().HasKey(x => x.KeyID);
            modelBuilder.Entity<eType>().HasKey(x => x.KeyID);
            #endregion

            #region Ignore
            modelBuilder.Entity<eImportProductProvider>().Ignore(x => x.eImportProductProviderDetails);

            modelBuilder.Entity<eCountry>().Ignore(x => x.Note);
            modelBuilder.Entity<eCountry>().Ignore(x => x.PostalCode);
            modelBuilder.Entity<eCountry>().Ignore(x => x.LocationCode);
            modelBuilder.Entity<eCountry>().Ignore(x => x.ZipCode);
            modelBuilder.Entity<eCountry>().Ignore(x => x.CountryCode);
            modelBuilder.Entity<eCountry>().Ignore(x => x.TypeCode);
            modelBuilder.Entity<eCountry>().Ignore(x => x.Code);
            modelBuilder.Entity<eCountry>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<eCountry>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<eCountry>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<eCountry>().Ignore(x => x.ModifiedBy);

            modelBuilder.Entity<xPermission>().Ignore(x => x.Code);
            modelBuilder.Entity<xPermission>().Ignore(x => x.Name);
            modelBuilder.Entity<xPermission>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<xPermission>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<xPermission>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<xPermission>().Ignore(x => x.Note);

            modelBuilder.Entity<xAccount>().Ignore(x => x.Code);
            modelBuilder.Entity<xAccount>().Ignore(x => x.Name);

            modelBuilder.Entity<xHistory>().Ignore(x => x.Code);
            modelBuilder.Entity<xHistory>().Ignore(x => x.Name);
            modelBuilder.Entity<xHistory>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<xHistory>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<xHistory>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<xHistory>().Ignore(x => x.ModifiedBy);
            modelBuilder.Entity<xHistory>().Ignore(x => x.Note);

            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.Code);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.Name);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.ModifiedBy);
            modelBuilder.Entity<eExchangeUnit>().Ignore(x => x.Note);

            modelBuilder.Entity<eType>().Ignore(x => x.Code);
            modelBuilder.Entity<eType>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<eType>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<eType>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<eType>().Ignore(x => x.ModifiedBy);
            modelBuilder.Entity<eType>().Ignore(x => x.Note);

            modelBuilder.Entity<eCurrency>().Ignore(x => x.CreatedDate);
            modelBuilder.Entity<eCurrency>().Ignore(x => x.CreatedBy);
            modelBuilder.Entity<eCurrency>().Ignore(x => x.ModifiedDate);
            modelBuilder.Entity<eCurrency>().Ignore(x => x.ModifiedBy);
            modelBuilder.Entity<eCurrency>().Ignore(x => x.Note);
            #endregion
        }
    }

    public class CustomConfiguration : DbMigrationsConfiguration<zModel>
    {
        public CustomConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(zModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}