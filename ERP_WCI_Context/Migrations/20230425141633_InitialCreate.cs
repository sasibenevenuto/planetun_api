using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_WCI_Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    EmailAccount = table.Column<string>(maxLength: 300, nullable: false),
                    TypeAccount = table.Column<int>(nullable: false),
                    CompanyActived = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_AccountId", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    LoginToken = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    BrokerCode = table.Column<string>(maxLength: 300, nullable: true),
                    ProductCode = table.Column<string>(maxLength: 300, nullable: true),
                    ProductName = table.Column<string>(maxLength: 300, nullable: true),
                    InspectionNumber = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_InspectionId", x => x.InspectionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductUnit",
                columns: table => new
                {
                    ProductUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ProductUnitId", x => x.ProductUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ProfileId", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    FederativeUnit = table.Column<string>(nullable: true),
                    ExternalCode = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_StateId", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "WciClaims",
                columns: table => new
                {
                    WciClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(maxLength: 300, nullable: false),
                    NameType = table.Column<string>(maxLength: 300, nullable: false),
                    Value = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_WciClaimId", x => x.WciClaimId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    ExternalCode = table.Column<string>(maxLength: 300, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CityId", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile_x_Claims",
                columns: table => new
                {
                    Profile_x_ClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    WciClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Profile_x_ClaimConfigId", x => x.Profile_x_ClaimId);
                    table.ForeignKey(
                        name: "FK_Profile_x_Claims_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_x_Claims_WciClaims_WciClaimId",
                        column: x => x.WciClaimId,
                        principalTable: "WciClaims",
                        principalColumn: "WciClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 300, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 300, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_AddressId", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TradingName = table.Column<string>(maxLength: 300, nullable: false),
                    FantasyName = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: true),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    CNAE = table.Column<string>(maxLength: 20, nullable: true),
                    MunicipalityRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    StateRegistrationReplaceTributary = table.Column<string>(maxLength: 20, nullable: true),
                    LogoBase64 = table.Column<string>(maxLength: 2147483647, nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CompanyId", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyConfigNfes",
                columns: table => new
                {
                    CompanyConfigNFeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CurrentNumberNfe = table.Column<int>(nullable: false),
                    VersionNfe = table.Column<string>(maxLength: 20, nullable: false),
                    EnvironmentNFE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CompanyConfigNFeId", x => x.CompanyConfigNFeId);
                    table.ForeignKey(
                        name: "FK_CompanyConfigNfes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    TradingName = table.Column<string>(maxLength: 300, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 300, nullable: true),
                    CPFCNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    MunicipalityRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    Suframa = table.Column<string>(maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneNumbers = table.Column<string>(maxLength: 20, nullable: true),
                    AddressNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 300, nullable: true),
                    Observation = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CustomerId", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    PersonalInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    IndividualResistration = table.Column<string>(maxLength: 20, nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_PersonalInformationId", x => x.PersonalInformationId);
                    table.ForeignKey(
                        name: "FK_PersonalInformations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInformations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberCompany",
                columns: table => new
                {
                    PhoneNumberCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    TypePhone = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    MainPhone = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberCompany", x => x.PhoneNumberCompanyId);
                    table.ForeignKey(
                        name: "FK_PhoneNumberCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductNCM",
                columns: table => new
                {
                    ProductNCMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    NCM = table.Column<string>(maxLength: 20, nullable: false),
                    Simple = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SimpleTaxSubstitution = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BCICMS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMSOrigin = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMSDestination = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MarginValueAggregate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BCICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ValueIcms_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ProductNCMId", x => x.ProductNCMId);
                    table.ForeignKey(
                        name: "FK_ProductNCM_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    DateBudget = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidateBudget = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_BudgetId", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CustomerAddressId", x => x.CustomerAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbersPersonalInformation",
                columns: table => new
                {
                    PhoneNumberPersonalInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    TypePhone = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: true),
                    MainPhone = table.Column<bool>(nullable: false),
                    PersonalInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_PhoneNumberPersonalInformationId", x => x.PhoneNumberPersonalInformationId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbersPersonalInformation_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(maxLength: 20, nullable: false),
                    EuropeanArticleNumber = table.Column<string>(maxLength: 20, nullable: true),
                    EuropeanArticleNumberUT = table.Column<string>(maxLength: 20, nullable: true),
                    ExTipi = table.Column<string>(nullable: true),
                    CEST = table.Column<string>(nullable: true),
                    ProductNCMId = table.Column<int>(nullable: false),
                    ProductUnitCommercialId = table.Column<int>(nullable: false),
                    ValueCommercialUnit = table.Column<decimal>(nullable: false),
                    ProductUnitTributaryId = table.Column<int>(nullable: false),
                    TributaryAmount = table.Column<decimal>(nullable: false),
                    ValueTributaryUnit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ProductId", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductNCM_ProductNCMId",
                        column: x => x.ProductNCMId,
                        principalTable: "ProductNCM",
                        principalColumn: "ProductNCMId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductUnit_ProductUnitCommercialId",
                        column: x => x.ProductUnitCommercialId,
                        principalTable: "ProductUnit",
                        principalColumn: "ProductUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductUnit_ProductUnitTributaryId",
                        column: x => x.ProductUnitTributaryId,
                        principalTable: "ProductUnit",
                        principalColumn: "ProductUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetProducts",
                columns: table => new
                {
                    BudgetProductsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductPriceBudget = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    BudgetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_BudgetProductsId", x => x.BudgetProductsId);
                    table.ForeignKey(
                        name: "FK_BudgetProducts_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetProducts_BudgetId",
                table: "BudgetProducts",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetProducts_ProductId",
                table: "BudgetProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CustomerId",
                table: "Budgets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AccountId",
                table: "Companies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConfigNfes_CompanyId",
                table: "CompanyConfigNfes",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_AddressId",
                table: "PersonalInformations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_CompanyId",
                table: "PersonalInformations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberCompany_CompanyId",
                table: "PhoneNumberCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbersPersonalInformation_PersonalInformationId",
                table: "PhoneNumbersPersonalInformation",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNCM_CompanyId",
                table: "ProductNCM",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNCMId",
                table: "Products",
                column: "ProductNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnitCommercialId",
                table: "Products",
                column: "ProductUnitCommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnitTributaryId",
                table: "Products",
                column: "ProductUnitTributaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_x_Claims_ProfileId",
                table: "Profile_x_Claims",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_x_Claims_WciClaimId",
                table: "Profile_x_Claims",
                column: "WciClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BudgetProducts");

            migrationBuilder.DropTable(
                name: "CompanyConfigNfes");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "PhoneNumberCompany");

            migrationBuilder.DropTable(
                name: "PhoneNumbersPersonalInformation");

            migrationBuilder.DropTable(
                name: "Profile_x_Claims");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "WciClaims");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductNCM");

            migrationBuilder.DropTable(
                name: "ProductUnit");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
