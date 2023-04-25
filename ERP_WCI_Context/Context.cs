using ERP_WCI_Context.Budgets;
using ERP_WCI_Context.CommonConfig;
using ERP_WCI_Context.CompaniesConfig;
using ERP_WCI_Context.CustomersConfig;
using ERP_WCI_Context.IdentityConfig;
using ERP_WCI_Context.PlanetunConfig;
using ERP_WCI_Context.Products;
using ERP_WCI_Model.Budgets;
using ERP_WCI_Model.Common;
using ERP_WCI_Model.Companies;
using ERP_WCI_Model.Customers;
using ERP_WCI_Model.Identity;
using ERP_WCI_Model.Planetun;
using ERP_WCI_Model.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP_WCI_Context
{
    public class Context : IdentityDbContext<User>, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<PhoneNumberPersonalInformation> PhoneNumbersPersonalInformation { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyConfigNfe> CompanyConfigNfes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public DbSet<WciClaim> WciClaims { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Profile_x_Claim> Profile_x_Claims { get; set; }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetProducts> BudgetProducts { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNCM> ProductNCM { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }

        public DbSet<Inspection> Inspections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = StateConfig.StateConfigModelBuilder(modelBuilder);
            modelBuilder = CityConfig.CityConfigModelBuilder(modelBuilder);
            modelBuilder = AddressConfig.AddressConfigModelBuilder(modelBuilder);
            modelBuilder = PersonalInformationConfig.PersonalInformationConfigModelBuilder(modelBuilder);
            modelBuilder = PhoneNumberPersonalInformationConfig.PhoneNumberPersonalInformationConfigModelBuilder(modelBuilder);
            modelBuilder = AccountConfig.AccountConfigModelBuilder(modelBuilder);
            modelBuilder = CompanyConfig.CompanyConfigModelBuilder(modelBuilder);
            modelBuilder = CompanyConfigNfeConfig.CompanyConfigNfeConfigModelBuilder(modelBuilder);
            modelBuilder = CustomerConfig.CustomerConfigModelBuilder(modelBuilder);
            modelBuilder = CustomerAddressConfig.CustomerAddressConfigModelBuilder(modelBuilder);
            modelBuilder = BudgetConfig.BudgetConfigModelBuilder(modelBuilder);
            modelBuilder = BudgetProductsConfig.BudgetProductsConfigModelBuilder(modelBuilder);
            modelBuilder = WciClaimConfig.WciClaimsConfigModelBuilder(modelBuilder);
            modelBuilder = ProfileConfig.ProfileConfigModelBuilder(modelBuilder);
            modelBuilder = Profile_x_ClaimConfig.Profile_x_ClaimConfigModelBuilder(modelBuilder);
            modelBuilder = ProductConfig.ProductConfigModelBuilder(modelBuilder);
            modelBuilder = ProductNCMConfig.ProductNCMConfigModelBuilder(modelBuilder);
            modelBuilder = ProductUnitConfig.ProductUnitConfigModelBuilder(modelBuilder);
            modelBuilder = InspectionConfig.InspectionConfigModelBuilder(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
