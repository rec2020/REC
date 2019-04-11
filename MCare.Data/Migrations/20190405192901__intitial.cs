using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class _intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arrivals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivals", x => x.Id);
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
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    MobileIsVerified = table.Column<bool>(nullable: false),
                    OTP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountNumberInTree = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelegateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelegateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArabicName = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    PartnerCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArabicName = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: true),
                    Deserved = table.Column<decimal>(nullable: true),
                    Expenses = table.Column<decimal>(nullable: true),
                    Transfer = table.Column<decimal>(nullable: true),
                    Remiander = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TreeAccountNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<decimal>(nullable: false),
                    CurrencyTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDelegates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    DelegateTypeId = table.Column<int>(nullable: false),
                    CommissionValue = table.Column<decimal>(nullable: false),
                    CommissionPrecentage = table.Column<decimal>(nullable: false),
                    AccountNoTree = table.Column<string>(nullable: true),
                    DeservedAmount = table.Column<decimal>(nullable: false),
                    RemainderAmount = table.Column<decimal>(nullable: false),
                    TransferAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDelegates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDelegates_DelegateTypes_DelegateTypeId",
                        column: x => x.DelegateTypeId,
                        principalTable: "DelegateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDelegates_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForeignAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficeNumber = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    OfficeName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ResponsibleUser = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BankDetailId = table.Column<int>(nullable: true),
                    BankAccountNo = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignAgencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignAgencies_BankDetails_BankDetailId",
                        column: x => x.BankDetailId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencies_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencies_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    FirstPhone = table.Column<string>(nullable: true),
                    SecondPhone = table.Column<string>(nullable: true),
                    CustomerTypeId = table.Column<int>(nullable: false),
                    IdentiyImage = table.Column<string>(nullable: true),
                    FamilyImage = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UserDelegateId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_UserDelegates_UserDelegateId",
                        column: x => x.UserDelegateId,
                        principalTable: "UserDelegates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    Father = table.Column<string>(nullable: true),
                    GrandFather = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    FileNo = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    ReligionId = table.Column<int>(nullable: true),
                    BirhtDate = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    SocialStatusId = table.Column<int>(nullable: true),
                    FamilyNo = table.Column<int>(nullable: true),
                    NumberTime = table.Column<int>(nullable: true),
                    ContractDate = table.Column<string>(nullable: true),
                    EmployeeStatusId = table.Column<int>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    IssuePlace = table.Column<string>(nullable: true),
                    IssueDate = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    IdentitySource = table.Column<string>(nullable: true),
                    IdentityIssueDate = table.Column<string>(nullable: true),
                    IdentityExpireDate = table.Column<string>(nullable: true),
                    VisaNo = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<string>(nullable: true),
                    BorderNo = table.Column<string>(nullable: true),
                    EntrancePort = table.Column<string>(nullable: true),
                    KafeelNo = table.Column<int>(nullable: true),
                    KafeelName = table.Column<string>(nullable: true),
                    NewKafeelNo = table.Column<int>(nullable: true),
                    NewKafeelName = table.Column<string>(nullable: true),
                    NewKafeelAddress = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    DriverLicenseNo = table.Column<int>(nullable: true),
                    DriverLicenseIssueDate = table.Column<string>(nullable: true),
                    DriverLicenseExpireDate = table.Column<string>(nullable: true),
                    LicenseNo = table.Column<int>(nullable: true),
                    LicenseExpireDate = table.Column<string>(nullable: true),
                    AddressInOrigin = table.Column<string>(nullable: true),
                    PhonrInOrigin = table.Column<string>(nullable: true),
                    BasicSalary = table.Column<decimal>(nullable: true),
                    HousingAllowance = table.Column<decimal>(nullable: true),
                    TransportationAllowance = table.Column<decimal>(nullable: true),
                    FuelAllowance = table.Column<decimal>(nullable: true),
                    Amountdeducted = table.Column<decimal>(nullable: true),
                    Telephoneallowance = table.Column<decimal>(nullable: true),
                    Subsistence = table.Column<decimal>(nullable: true),
                    TotalSalary = table.Column<decimal>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    GroupNo = table.Column<int>(nullable: true),
                    EmbassyContractDate = table.Column<string>(nullable: true),
                    EmbassyContractNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeStatuses_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_SocialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "SocialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    ModifybyId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<string>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    ContractStatusId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    ContractDate = table.Column<string>(nullable: true),
                    ContractYear = table.Column<int>(nullable: true),
                    EmployeeNumber = table.Column<int>(nullable: true),
                    EmployeeCost = table.Column<decimal>(nullable: true),
                    VatCost = table.Column<decimal>(nullable: false),
                    ContractCost = table.Column<decimal>(nullable: false),
                    ArrivalCityId = table.Column<int>(nullable: true),
                    ContractNote = table.Column<string>(nullable: true),
                    TestDay = table.Column<int>(nullable: true),
                    ExperienceYear = table.Column<string>(nullable: true),
                    ContractInterVal = table.Column<int>(nullable: true),
                    SalaryMonth = table.Column<decimal>(nullable: true),
                    VicationDays = table.Column<int>(nullable: true),
                    QulaficationNote = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    OldContractNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Cities_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractDelegations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    DelegationDate = table.Column<string>(nullable: true),
                    DelegateById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDelegations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDelegations_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractDelegations_AspNetUsers_DelegateById",
                        column: x => x.DelegateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractDelegations_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: false),
                    ContractStatusId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    ActionDate = table.Column<string>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    ActionById = table.Column<string>(nullable: true),
                    ActionId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractHistories_AspNetUsers_ActionById",
                        column: x => x.ActionById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_ContractAction_ActionId",
                        column: x => x.ActionId,
                        principalTable: "ContractAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractHistories_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractSelects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: false),
                    SelectDate = table.Column<string>(nullable: true),
                    PolNumer = table.Column<int>(nullable: true),
                    PolNumerDate = table.Column<string>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    SelectById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractSelects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractSelects_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractSelects_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractSelects_AspNetUsers_SelectById",
                        column: x => x.SelectById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    ArrivalDate = table.Column<string>(nullable: true),
                    TicketDate = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    AirLineName = table.Column<string>(nullable: true),
                    TicketById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTickets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractTickets_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractTickets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractTickets_AspNetUsers_TicketById",
                        column: x => x.TicketById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractVisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    VisaDate = table.Column<string>(nullable: true),
                    VisaById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractVisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractVisas_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractVisas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractVisas_AspNetUsers_VisaById",
                        column: x => x.VisaById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContractAction",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "تم انشاء العقد" },
                    { 2, "تم الاختيار" },
                    { 3, "تم التفويض" },
                    { 4, "تم التفيز" },
                    { 5, "تم حجز تذكرة سفر" },
                    { 6, "تم الاسترجاع" },
                    { 7, "تم الاغلاق " }
                });

            migrationBuilder.InsertData(
                table: "ContractStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "انتهي" },
                    { 6, "استرجاع" },
                    { 5, "تذكرة سفر" },
                    { 2, "تم الاختيار" },
                    { 3, "تم التفويض" },
                    { 1, "جديد" },
                    { 4, "تم التفيز" }
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "معين" },
                    { 1, "أستقدام" },
                    { 3, "بديل" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "عملة أجنبية" },
                    { 1, "عملة محلية" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "داخلي" },
                    { 2, "خارجي" }
                });

            migrationBuilder.InsertData(
                table: "DelegateTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مندوب داخلي " },
                    { 2, "مندوب خارجي " }
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "نقل كفالة" },
                    { 7, "جديد" },
                    { 6, "في السكن" },
                    { 4, "هروب" },
                    { 3, "خروج نهائي" },
                    { 2, "تجربة" },
                    { 1, "علي راس العمل" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ذكر" },
                    { 2, "أنثي" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "السعودية" },
                    { 2, "مصر" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مسلم" },
                    { 2, "مسيحي" }
                });

            migrationBuilder.InsertData(
                table: "SocialStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "عازب/ة" },
                    { 2, "متزوج/ة" }
                });

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
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ContractId",
                table: "ContractDelegations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations",
                column: "DelegateById",
                unique: true,
                filter: "[DelegateById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionById",
                table: "ContractHistories",
                column: "ActionById",
                unique: true,
                filter: "[ActionById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories",
                column: "ActionId",
                unique: true,
                filter: "[ActionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractId",
                table: "ContractHistories",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories",
                column: "ContractStatusId",
                unique: true,
                filter: "[ContractStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_CustomerId",
                table: "ContractHistories",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_EmployeeId",
                table: "ContractHistories",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ForeignAgencyId",
                table: "ContractHistories",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts",
                column: "ArrivalCityId",
                unique: true,
                filter: "[ArrivalCityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId",
                unique: true,
                filter: "[ContractStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId",
                unique: true,
                filter: "[ContractTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerId",
                table: "Contracts",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ContractId",
                table: "ContractSelects",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects",
                column: "SelectById",
                unique: true,
                filter: "[SelectById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets",
                column: "CityId",
                unique: true,
                filter: "[CityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_ContractId",
                table: "ContractTickets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets",
                column: "TicketById",
                unique: true,
                filter: "[TicketById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_ContractId",
                table: "ContractVisas",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas",
                column: "VisaById",
                unique: true,
                filter: "[VisaById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies",
                column: "CurrencyTypeId",
                unique: true,
                filter: "[CurrencyTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserDelegateId",
                table: "Customers",
                column: "UserDelegateId",
                unique: true,
                filter: "[UserDelegateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId",
                unique: true,
                filter: "[EmployeeStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees",
                column: "ForeignAgencyId",
                unique: true,
                filter: "[ForeignAgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId",
                unique: true,
                filter: "[GenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees",
                column: "ReligionId",
                unique: true,
                filter: "[ReligionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees",
                column: "SocialStatusId",
                unique: true,
                filter: "[SocialStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies",
                column: "BankDetailId",
                unique: true,
                filter: "[BankDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_CurrencyId",
                table: "ForeignAgencies",
                column: "CurrencyId",
                unique: true,
                filter: "[CurrencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_JobTypeId",
                table: "ForeignAgencies",
                column: "JobTypeId",
                unique: true,
                filter: "[JobTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_NationalityId",
                table: "ForeignAgencies",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates",
                column: "DelegateTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates",
                column: "NationalityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrivals");

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
                name: "ContractDelegations");

            migrationBuilder.DropTable(
                name: "ContractHistories");

            migrationBuilder.DropTable(
                name: "ContractSelects");

            migrationBuilder.DropTable(
                name: "ContractTickets");

            migrationBuilder.DropTable(
                name: "ContractVisas");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContractAction");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ContractStatuses");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "UserDelegates");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");

            migrationBuilder.DropTable(
                name: "ForeignAgencies");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "SocialStatuses");

            migrationBuilder.DropTable(
                name: "DelegateTypes");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");
        }
    }
}
