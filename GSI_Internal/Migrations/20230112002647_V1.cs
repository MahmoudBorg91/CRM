using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSI_Internal.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhatsAppNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndConditionsAr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Move_Type = table.Column<int>(type: "int", nullable: false),
                    The_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransiactionItem_Code = table.Column<int>(type: "int", nullable: false),
                    TransiactionItem_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransiactionItem_GovernmentFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransiactionItem_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransiactionItem_Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfTransiactionOfEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarnferUserFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferUserTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProsessByUser = table.Column<int>(type: "int", nullable: false),
                    UserProsessID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProsessID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RequestSelection_Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Selection_GroupName_Arab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selection_GroupName_English = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RequestSelection_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Requirements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequirementName_English = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Requirements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SlideShow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReSizeme_English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReSizeme_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInMobile = table.Column<bool>(type: "bit", nullable: false),
                    ShowInWeb = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SlideShow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StatusTransfer_Name",
                columns: table => new
                {
                    StatusAction_Code = table.Column<int>(type: "int", nullable: false),
                    StatusAction_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionGroup_NameArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionGroup_NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNotAvailbale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionItem_Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionItem_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionItemInquiry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryName_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquiryName_English = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inquiry_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionItemInquiry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "NotificationsConfirmed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsConfirmed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationsConfirmed_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationsConfirmed_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request_Log",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    The_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTransiactionOfEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_code = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_From = table.Column<int>(type: "int", nullable: false),
                    Status_TO = table.Column<int>(type: "int", nullable: false),
                    File_Processing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_ApplicationTransaction_Request_Log_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransaction_Request_Processing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTransactionTimeToProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveStatus = table.Column<int>(type: "int", nullable: false),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransaction_Request_Processing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_ApplicationTransaction_Request_Processing_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ApplicationTransfer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transfer_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApplicationTransfer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_ApplicationTransfer_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransiactionItem_Selection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionGroupID = table.Column<int>(type: "int", nullable: false),
                    SelectionName_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectionName_English = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransiactionItem_Selection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_TransiactionItem_Selection_tbl_RequestSelection_Group_SelectionGroupID",
                        column: x => x.SelectionGroupID,
                        principalTable: "tbl_RequestSelection_Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_client_wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequireID = table.Column<int>(type: "int", nullable: false),
                    TheDateFile = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_client_wallet_tbl_Requirements_RequireID",
                        column: x => x.RequireID,
                        principalTable: "tbl_Requirements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RequirmentsFileAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequireID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RequirmentsFileAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RequirmentsFileAttachment_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RequirmentsFileAttachment_tbl_Requirements_RequireID",
                        column: x => x.RequireID,
                        principalTable: "tbl_Requirements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionSubGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubGroupNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubGroupNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionGroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionSubGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionSubGroup_tbl_TransactionGroup_TransactionGroupID",
                        column: x => x.TransactionGroupID,
                        principalTable: "tbl_TransactionGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RequestInquiry_Answer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InquiryID = table.Column<int>(type: "int", nullable: false),
                    Inquiry_Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RequestInquiry_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_RequestInquiry_Answer_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RequestInquiry_Answer_tbl_TransactionItemInquiry_InquiryID",
                        column: x => x.InquiryID,
                        principalTable: "tbl_TransactionItemInquiry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestSelection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSelection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestSelection_tbl_ApplicationTransaction_Request_App_Code",
                        column: x => x.App_Code,
                        principalTable: "tbl_ApplicationTransaction_Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestSelection_tbl_TransiactionItem_Selection_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "tbl_TransiactionItem_Selection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionGroupID = table.Column<int>(type: "int", nullable: false),
                    TransactionSubGroupID = table.Column<int>(type: "int", nullable: false),
                    TransactionNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicesPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesDecription_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesDecription_English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetInMostServices = table.Column<bool>(type: "bit", nullable: false),
                    SetInMostServices_INSubGroup = table.Column<bool>(type: "bit", nullable: false),
                    Time_Services_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_Services_English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Services_Conditions_Arabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Services_Conditions_English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionItemTypeId = table.Column<int>(type: "int", nullable: false),
                    NextSubservicesID = table.Column<int>(type: "int", nullable: false),
                    IsNotAvailbale = table.Column<bool>(type: "bit", nullable: false),
                    ItemServiceTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionItem_tbl_TransactionGroup_TransactionGroupID",
                        column: x => x.TransactionGroupID,
                        principalTable: "tbl_TransactionGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionItem_tbl_TransactionItem_Type_ItemServiceTypeID",
                        column: x => x.ItemServiceTypeID,
                        principalTable: "tbl_TransactionItem_Type",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbl_TransactionItem_tbl_TransactionSubGroup_TransactionSubGroupID",
                        column: x => x.TransactionSubGroupID,
                        principalTable: "tbl_TransactionSubGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AssignInquiryToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    InquiryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignInquiryToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignInquiryToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignInquiryToItem_tbl_TransactionItemInquiry_InquiryID",
                        column: x => x.InquiryID,
                        principalTable: "tbl_TransactionItemInquiry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AssignRequirmentToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    RequirmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignRequirmentToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignRequirmentToItem_tbl_Requirements_RequirmentID",
                        column: x => x.RequirmentID,
                        principalTable: "tbl_Requirements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignRequirmentToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AssignSelectionToItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionItemID = table.Column<int>(type: "int", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AssignSelectionToItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_AssignSelectionToItem_tbl_TransactionItem_TransactionItemID",
                        column: x => x.TransactionItemID,
                        principalTable: "tbl_TransactionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_AssignSelectionToItem_tbl_TransiactionItem_Selection_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "tbl_TransiactionItem_Selection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_NotificationsConfirmed_NotificationId",
                table: "NotificationsConfirmed",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsConfirmed_UserId",
                table: "NotificationsConfirmed",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelection_App_Code",
                table: "RequestSelection",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelection_SelectionID",
                table: "RequestSelection",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ApplicationTransaction_Request_Log_App_Code",
                table: "tbl_ApplicationTransaction_Request_Log",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ApplicationTransaction_Request_Processing_App_Code",
                table: "tbl_ApplicationTransaction_Request_Processing",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ApplicationTransfer_App_Code",
                table: "tbl_ApplicationTransfer",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignInquiryToItem_InquiryID",
                table: "tbl_AssignInquiryToItem",
                column: "InquiryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignInquiryToItem_TransactionItemID",
                table: "tbl_AssignInquiryToItem",
                column: "TransactionItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignRequirmentToItem_RequirmentID",
                table: "tbl_AssignRequirmentToItem",
                column: "RequirmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignRequirmentToItem_TransactionItemID",
                table: "tbl_AssignRequirmentToItem",
                column: "TransactionItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignSelectionToItem_SelectionID",
                table: "tbl_AssignSelectionToItem",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AssignSelectionToItem_TransactionItemID",
                table: "tbl_AssignSelectionToItem",
                column: "TransactionItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_wallet_RequireID",
                table: "tbl_client_wallet",
                column: "RequireID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequestInquiry_Answer_App_Code",
                table: "tbl_RequestInquiry_Answer",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequestInquiry_Answer_InquiryID",
                table: "tbl_RequestInquiry_Answer",
                column: "InquiryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequirmentsFileAttachment_App_Code",
                table: "tbl_RequirmentsFileAttachment",
                column: "App_Code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequirmentsFileAttachment_RequireID",
                table: "tbl_RequirmentsFileAttachment",
                column: "RequireID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_ItemServiceTypeID",
                table: "tbl_TransactionItem",
                column: "ItemServiceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_TransactionGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionItem_TransactionSubGroupID",
                table: "tbl_TransactionItem",
                column: "TransactionSubGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionSubGroup_TransactionGroupID",
                table: "tbl_TransactionSubGroup",
                column: "TransactionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransiactionItem_Selection_SelectionGroupID",
                table: "tbl_TransiactionItem_Selection",
                column: "SelectionGroupID");
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
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "NotificationsConfirmed");

            migrationBuilder.DropTable(
                name: "RequestSelection");

            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request_Log");

            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request_Processing");

            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransfer");

            migrationBuilder.DropTable(
                name: "tbl_AssignInquiryToItem");

            migrationBuilder.DropTable(
                name: "tbl_AssignRequirmentToItem");

            migrationBuilder.DropTable(
                name: "tbl_AssignSelectionToItem");

            migrationBuilder.DropTable(
                name: "tbl_client_wallet");

            migrationBuilder.DropTable(
                name: "tbl_RequestInquiry_Answer");

            migrationBuilder.DropTable(
                name: "tbl_RequirmentsFileAttachment");

            migrationBuilder.DropTable(
                name: "tbl_SlideShow");

            migrationBuilder.DropTable(
                name: "tbl_StatusTransfer_Name");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "tbl_TransactionItem");

            migrationBuilder.DropTable(
                name: "tbl_TransiactionItem_Selection");

            migrationBuilder.DropTable(
                name: "tbl_TransactionItemInquiry");

            migrationBuilder.DropTable(
                name: "tbl_ApplicationTransaction_Request");

            migrationBuilder.DropTable(
                name: "tbl_Requirements");

            migrationBuilder.DropTable(
                name: "tbl_TransactionItem_Type");

            migrationBuilder.DropTable(
                name: "tbl_TransactionSubGroup");

            migrationBuilder.DropTable(
                name: "tbl_RequestSelection_Group");

            migrationBuilder.DropTable(
                name: "tbl_TransactionGroup");
        }
    }
}
