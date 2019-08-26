using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NajmetAlraqee.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountClassificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClassificationTypes", x => x.Id);
                });

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
                    AccountNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPeriodStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriodStatuses", x => x.Id);
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
                name: "ReceiptDocTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDocTypes", x => x.Id);
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
                name: "ReturnReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnadReceiptCaluses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnadReceiptCaluses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnadReceiptTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnadReceiptTypes", x => x.Id);
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
                name: "TransferPurposes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionAr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountClassifications_AccountClassificationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccountClassificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ForeignAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficeNumber = table.Column<int>(nullable: true),
                    OfficeName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ResponsibleUser = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BankDetailId = table.Column<int>(nullable: true),
                    BankAccountNo = table.Column<string>(nullable: true),
                    DeservedAmount = table.Column<decimal>(nullable: true),
                    RemainderAmount = table.Column<decimal>(nullable: true),
                    TransferAmount = table.Column<decimal>(nullable: true),
                    OpenBalance = table.Column<decimal>(nullable: true),
                    CloseBalance = table.Column<decimal>(nullable: true)
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
                name: "FinancialPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    FromData = table.Column<string>(nullable: true),
                    ToDate = table.Column<string>(nullable: true),
                    FinancialPeriodStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPeriods_FinancialPeriodStatuses_FinancialPeriodStatusId",
                        column: x => x.FinancialPeriodStatusId,
                        principalTable: "FinancialPeriodStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialEmployees_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
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
                name: "SnadReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SnadReceiptTypeId = table.Column<int>(nullable: true),
                    ExpenseId = table.Column<int>(nullable: true),
                    SnadDate = table.Column<string>(nullable: true),
                    FinancialYear = table.Column<int>(nullable: false),
                    QuidNumber = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    SnadByUser = table.Column<string>(nullable: true),
                    SnadByUserName = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnadReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnadReceipts_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SnadReceipts_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SnadReceipts_SnadReceiptTypes_SnadReceiptTypeId",
                        column: x => x.SnadReceiptTypeId,
                        principalTable: "SnadReceiptTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountTrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNo = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    AccountLevel = table.Column<int>(nullable: true),
                    AccClassificationId = table.Column<int>(nullable: true),
                    AccTypeId = table.Column<int>(nullable: true),
                    Accprev = table.Column<string>(nullable: true),
                    Debit = table.Column<decimal>(nullable: true),
                    Credit = table.Column<decimal>(nullable: true),
                    Balance = table.Column<decimal>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    PriceInExhibtion = table.Column<decimal>(nullable: true),
                    HighLimitForBalance = table.Column<decimal>(nullable: true),
                    EhalkPrecent = table.Column<int>(nullable: true),
                    FixedAssetDate = table.Column<string>(nullable: true),
                    JE = table.Column<string>(nullable: true),
                    CostCenter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTrees_AccountClassifications_AccClassificationId",
                        column: x => x.AccClassificationId,
                        principalTable: "AccountClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTrees_AccountClassificationTypes_AccTypeId",
                        column: x => x.AccTypeId,
                        principalTable: "AccountClassificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTrees_AccountTrees_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AccountTrees",
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
                name: "ForeignAgencyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NationalityId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignAgencyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyJobs_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyJobs_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyJobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyJobs_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForeignAgencyTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransferDate = table.Column<string>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    TransferBankId = table.Column<int>(nullable: true),
                    PurposeId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignAgencyTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyTransfers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyTransfers_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyTransfers_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyTransfers_TransferPurposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "TransferPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignAgencyTransfers_BankDetails_TransferBankId",
                        column: x => x.TransferBankId,
                        principalTable: "BankDetails",
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
                    IsActive = table.Column<bool>(nullable: true),
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
                name: "DelegateTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransferDate = table.Column<string>(nullable: true),
                    UserDelegateId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    TransferBankId = table.Column<int>(nullable: true),
                    PurposeId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelegateTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelegateTransfers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegateTransfers_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegateTransfers_TransferPurposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "TransferPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegateTransfers_BankDetails_TransferBankId",
                        column: x => x.TransferBankId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegateTransfers_UserDelegates_UserDelegateId",
                        column: x => x.UserDelegateId,
                        principalTable: "UserDelegates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<string>(nullable: true),
                    ModifybyId = table.Column<string>(nullable: true),
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
                    Remainder = table.Column<decimal>(nullable: true),
                    Paid = table.Column<decimal>(nullable: true),
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
                    OldContractNo = table.Column<int>(nullable: true),
                    VisaNumber = table.Column<int>(nullable: true),
                    VisaDate = table.Column<string>(nullable: true)
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
                name: "SpecificContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    SpecialEmployeeId = table.Column<int>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    ForeignAgencyName = table.Column<string>(nullable: true),
                    ContractDate = table.Column<string>(nullable: true),
                    ContractInterVal = table.Column<decimal>(nullable: false),
                    LicenceNumber = table.Column<string>(nullable: true),
                    ContractCost = table.Column<decimal>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    DelegationDate = table.Column<string>(nullable: true),
                    ContractStatusId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    QulaficationNote = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    Remainder = table.Column<decimal>(nullable: true),
                    Paid = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_ForeignAgencies_ForeignAgencyId",
                        column: x => x.ForeignAgencyId,
                        principalTable: "ForeignAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificContracts_SpecialEmployees_SpecialEmployeeId",
                        column: x => x.SpecialEmployeeId,
                        principalTable: "SpecialEmployees",
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
                    EmployeeName = table.Column<string>(nullable: true),
                    ActionDate = table.Column<string>(nullable: true),
                    ForeignAgencyId = table.Column<int>(nullable: true),
                    ForeignAgencyName = table.Column<string>(nullable: true),
                    ActionById = table.Column<string>(nullable: true),
                    ActionByName = table.Column<string>(nullable: true),
                    ActionId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractHistories", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "ContractReturns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    ReturnReasonId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    EmployeeReturnDate = table.Column<string>(nullable: true),
                    KafeelName = table.Column<string>(nullable: true),
                    KafeelPhone = table.Column<string>(nullable: true),
                    KafeelAddress = table.Column<string>(nullable: true),
                    KfalaTranportDate = table.Column<string>(nullable: true),
                    ExitDate = table.Column<string>(nullable: true),
                    ExitTime = table.Column<string>(nullable: true),
                    AirLine = table.Column<string>(nullable: true),
                    CancelDate = table.Column<string>(nullable: true),
                    CancelNote = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractReturns_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractReturns_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractReturns_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractReturns_ReturnReasons_ReturnReasonId",
                        column: x => x.ReturnReasonId,
                        principalTable: "ReturnReasons",
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
                    TicketById = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ReceiptDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReceiptdocTypeId = table.Column<int>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ReceiptDate = table.Column<string>(nullable: true),
                    ReceiptByUser = table.Column<string>(nullable: true),
                    ReceiptByUserName = table.Column<string>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    QaidNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptDocs_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptDocs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptDocs_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptDocs_ReceiptDocTypes_ReceiptdocTypeId",
                        column: x => x.ReceiptdocTypeId,
                        principalTable: "ReceiptDocTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountClassificationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ميزانية" },
                    { 2, "قائمة الدخل" }
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
                    { 4, "تم التفيز" },
                    { 5, "تذكرة سفر" },
                    { 2, "تم الاختيار" },
                    { 1, "جديد" },
                    { 3, "تم التفويض" }
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "أستقدام" },
                    { 3, "معين" },
                    { 2, "بديل" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "عملة محلية" },
                    { 2, "عملة أجنبية" }
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
                    { 6, "في السكن" },
                    { 7, "جديد" },
                    { 4, "هروب" },
                    { 5, "نقل كفالة" },
                    { 2, "تجربة" },
                    { 1, "علي راس العمل" },
                    { 3, "خروج نهائي" }
                });

            migrationBuilder.InsertData(
                table: "FinancialPeriodStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CURRENT" },
                    { 2, "OPEN" },
                    { 3, "CLOSE" }
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
                table: "ReceiptDocTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "سند صرف " },
                    { 2, "سند قبض" }
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
                table: "ReturnReasons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "الغاء التعامل" },
                    { 3, "خروج نهائي" },
                    { 1, "السكن" },
                    { 2, "نقل الكفالة" }
                });

            migrationBuilder.InsertData(
                table: "SnadReceiptCaluses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "أيجار" },
                    { 2, "رسوم حكومية" }
                });

            migrationBuilder.InsertData(
                table: "SnadReceiptTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ضريبي" },
                    { 2, "غير ضريبي" }
                });

            migrationBuilder.InsertData(
                table: "SocialStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "عازب/ة" },
                    { 2, "متزوج/ة" }
                });

            migrationBuilder.InsertData(
                table: "TransferPurposes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "انجاز " },
                    { 3, "راتب" },
                    { 5, "غرامة تاخير" },
                    { 1, "رسوم عمالة" },
                    { 2, "تذكرة سفر" },
                    { 6, "أخري" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountClassifications_TypeId",
                table: "AccountClassifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrees_AccClassificationId",
                table: "AccountTrees",
                column: "AccClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrees_AccTypeId",
                table: "AccountTrees",
                column: "AccTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrees_ParentId",
                table: "AccountTrees",
                column: "ParentId");

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
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ContractId",
                table: "ContractDelegations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_DelegateById",
                table: "ContractDelegations",
                column: "DelegateById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDelegations_ForeignAgencyId",
                table: "ContractDelegations",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ActionId",
                table: "ContractHistories",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractId",
                table: "ContractHistories",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_ContractStatusId",
                table: "ContractHistories",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReturns_ContractId",
                table: "ContractReturns",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReturns_ContractTypeId",
                table: "ContractReturns",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReturns_EmployeeId",
                table: "ContractReturns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReturns_ReturnReasonId",
                table: "ContractReturns",
                column: "ReturnReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArrivalCityId",
                table: "Contracts",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerId",
                table: "Contracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ForeignAgencyId",
                table: "Contracts",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ContractId",
                table: "ContractSelects",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_ForeignAgencyId",
                table: "ContractSelects",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSelects_SelectById",
                table: "ContractSelects",
                column: "SelectById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_CityId",
                table: "ContractTickets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_ContractId",
                table: "ContractTickets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_EmployeeId",
                table: "ContractTickets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTickets_TicketById",
                table: "ContractTickets",
                column: "TicketById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_ContractId",
                table: "ContractVisas",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_EmployeeId",
                table: "ContractVisas",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractVisas_VisaById",
                table: "ContractVisas",
                column: "VisaById");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyTypeId",
                table: "Currencies",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserDelegateId",
                table: "Customers",
                column: "UserDelegateId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_CurrencyId",
                table: "DelegateTransfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_PaymentMethodId",
                table: "DelegateTransfers",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_PurposeId",
                table: "DelegateTransfers",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_TransferBankId",
                table: "DelegateTransfers",
                column: "TransferBankId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegateTransfers_UserDelegateId",
                table: "DelegateTransfers",
                column: "UserDelegateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ForeignAgencyId",
                table: "Employees",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                table: "Employees",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SocialStatusId",
                table: "Employees",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPeriods_FinancialPeriodStatusId",
                table: "FinancialPeriods",
                column: "FinancialPeriodStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencies_BankDetailId",
                table: "ForeignAgencies",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyJobs_CurrencyId",
                table: "ForeignAgencyJobs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyJobs_ForeignAgencyId",
                table: "ForeignAgencyJobs",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyJobs_JobTypeId",
                table: "ForeignAgencyJobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyJobs_NationalityId",
                table: "ForeignAgencyJobs",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_CurrencyId",
                table: "ForeignAgencyTransfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_ForeignAgencyId",
                table: "ForeignAgencyTransfers",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_PaymentMethodId",
                table: "ForeignAgencyTransfers",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_PurposeId",
                table: "ForeignAgencyTransfers",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgencyTransfers_TransferBankId",
                table: "ForeignAgencyTransfers",
                column: "TransferBankId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocs_ContractId",
                table: "ReceiptDocs",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocs_CustomerId",
                table: "ReceiptDocs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocs_PaymentMethodId",
                table: "ReceiptDocs",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocs_ReceiptdocTypeId",
                table: "ReceiptDocs",
                column: "ReceiptdocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SnadReceipts_ExpenseId",
                table: "SnadReceipts",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_SnadReceipts_PaymentMethodId",
                table: "SnadReceipts",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SnadReceipts_SnadReceiptTypeId",
                table: "SnadReceipts",
                column: "SnadReceiptTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialEmployees_NationalityId",
                table: "SpecialEmployees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_ContractStatusId",
                table: "SpecificContracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_ContractTypeId",
                table: "SpecificContracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_CountryId",
                table: "SpecificContracts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_CustomerId",
                table: "SpecificContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_ForeignAgencyId",
                table: "SpecificContracts",
                column: "ForeignAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_JobTypeId",
                table: "SpecificContracts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificContracts_SpecialEmployeeId",
                table: "SpecificContracts",
                column: "SpecialEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_DelegateTypeId",
                table: "UserDelegates",
                column: "DelegateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDelegates_NationalityId",
                table: "UserDelegates",
                column: "NationalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTrees");

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
                name: "ContractReturns");

            migrationBuilder.DropTable(
                name: "ContractSelects");

            migrationBuilder.DropTable(
                name: "ContractTickets");

            migrationBuilder.DropTable(
                name: "ContractVisas");

            migrationBuilder.DropTable(
                name: "DelegateTransfers");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "FinancialPeriods");

            migrationBuilder.DropTable(
                name: "ForeignAgencyJobs");

            migrationBuilder.DropTable(
                name: "ForeignAgencyTransfers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "ReceiptDocs");

            migrationBuilder.DropTable(
                name: "SnadReceiptCaluses");

            migrationBuilder.DropTable(
                name: "SnadReceipts");

            migrationBuilder.DropTable(
                name: "SpecificContracts");

            migrationBuilder.DropTable(
                name: "AccountClassifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContractAction");

            migrationBuilder.DropTable(
                name: "ReturnReasons");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FinancialPeriodStatuses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "TransferPurposes");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ReceiptDocTypes");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "SnadReceiptTypes");

            migrationBuilder.DropTable(
                name: "SpecialEmployees");

            migrationBuilder.DropTable(
                name: "AccountClassificationTypes");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");

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
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "SocialStatuses");

            migrationBuilder.DropTable(
                name: "DelegateTypes");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "BankDetails");
        }
    }
}
