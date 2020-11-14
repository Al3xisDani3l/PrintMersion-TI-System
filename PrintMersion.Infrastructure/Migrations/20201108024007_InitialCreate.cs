using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PrintMersion.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    InteriorNumber = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    ExteriorNumber = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    ZipCode = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(maxLength: 32, nullable: true),
                    Logitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Metadata = table.Column<string>(unicode: false, nullable: true),
                    DataRaw = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Category = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Model = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    UserName = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Role = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BotCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    IdAddress = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MessengerUserId = table.Column<string>(maxLength: 32, nullable: true),
                    Gender = table.Column<string>(maxLength: 32, nullable: true),
                    ProfilePicUrl = table.Column<string>(maxLength: 128, nullable: true),
                    TimeZone = table.Column<string>(maxLength: 32, nullable: true),
                    Locale = table.Column<string>(maxLength: 32, nullable: true),
                    Source = table.Column<string>(maxLength: 32, nullable: true),
                    LastSeen = table.Column<string>(maxLength: 32, nullable: true),
                    SignedUp = table.Column<string>(maxLength: 32, nullable: true),
                    Sessions = table.Column<string>(maxLength: 32, nullable: true),
                    LastVisitedBlockName = table.Column<string>(maxLength: 32, nullable: true),
                    LastVisitedBlockId = table.Column<string>(maxLength: 32, nullable: true),
                    LastClickedButtonName = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "fk_BotCustomers_Address",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    IdAddress = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Customers_Address",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs_Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdCatalog = table.Column<int>(nullable: false),
                    IdPicture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Catalogs_Pictures_Catalogs",
                        column: x => x.IdCatalog,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Catalogs_Pictures_Pictures",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs_Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdProduct = table.Column<int>(nullable: false),
                    IdCatalog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs_Products", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Catalogs_Products_Catalogs",
                        column: x => x.IdCatalog,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Catalogs_Products_Products",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdProduct = table.Column<int>(nullable: false),
                    IdPicture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Products_Pictures_Pictures",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Products_Pictures_Products",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tools_Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTools = table.Column<int>(nullable: false),
                    IdPicture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Tools_Pictures_Pictures",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Tools_Pictures_Tools",
                        column: x => x.IdTools,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogsTools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTool = table.Column<int>(nullable: false),
                    IdAdminister = table.Column<int>(nullable: false),
                    StartUse = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndUse = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsTools", x => x.Id);
                    table.ForeignKey(
                        name: "fk_LogsTools_Administers",
                        column: x => x.IdAdminister,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_LogsTools_Tool",
                        column: x => x.IdTool,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<int>(nullable: false),
                    IdPicture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPictures", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Users_Pictures_Pictures",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Users_Pictures_Users",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers_Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdPicture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Customers_Pictures_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Customers_Pictures_Pictures",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<int>(nullable: true),
                    Subtotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    DeliveryMethod = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    DetailedInformation = table.Column<string>(unicode: false, nullable: true),
                    Tracking = table.Column<string>(type: "char", unicode: false, maxLength: 36, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    PaymentMethod = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdAdminister = table.Column<int>(nullable: true),
                    BotCustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_BotCustomers_BotCustomerId",
                        column: x => x.BotCustomerId,
                        principalTable: "BotCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Orders_Users",
                        column: x => x.IdAdminister,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Orders_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Address__3214EC0650DF4974",
                table: "Address",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BotCustomers_Id",
                table: "BotCustomers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BotCustomers_IdAddress",
                table: "BotCustomers",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "UQ__Catalogs__3214EC069D79A489",
                table: "Catalogs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Pictures_IdCatalog",
                table: "Catalogs_Pictures",
                column: "IdCatalog");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Pictures_IdPicture",
                table: "Catalogs_Pictures",
                column: "IdPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Products_IdCatalog",
                table: "Catalogs_Products",
                column: "IdCatalog");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Products_IdProduct",
                table: "Catalogs_Products",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__3214EC06F6258619",
                table: "Customers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdAddress",
                table: "Customers",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Pictures_IdCustomer",
                table: "Customers_Pictures",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Pictures_IdPicture",
                table: "Customers_Pictures",
                column: "IdPicture");

            migrationBuilder.CreateIndex(
                name: "UQ__LogsTool__3214EC06BB600FAA",
                table: "LogsTools",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogsTools_IdAdminister",
                table: "LogsTools",
                column: "IdAdminister");

            migrationBuilder.CreateIndex(
                name: "IX_LogsTools_IdTool",
                table: "LogsTools",
                column: "IdTool");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BotCustomerId",
                table: "Orders",
                column: "BotCustomerId");

            migrationBuilder.CreateIndex(
                name: "UQ__Orders__3214EC068F9DCEBA",
                table: "Orders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdAdminister",
                table: "Orders",
                column: "IdAdminister");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "UQ__Pictures__3214EC069D4153E6",
                table: "Pictures",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Products__3214EC0658BFAAF7",
                table: "Products",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pictures_IdPicture",
                table: "Products_Pictures",
                column: "IdPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pictures_IdProduct",
                table: "Products_Pictures",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "UQ__Tools__3214EC06EEF22EC7",
                table: "Tools",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_Pictures_IdPicture",
                table: "Tools_Pictures",
                column: "IdPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_Pictures_IdTools",
                table: "Tools_Pictures",
                column: "IdTools");

            migrationBuilder.CreateIndex(
                name: "UQ__Administ__3214EC06F23652DC",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPictures_IdPicture",
                table: "UsersPictures",
                column: "IdPicture");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPictures_IdUser",
                table: "UsersPictures",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs_Pictures");

            migrationBuilder.DropTable(
                name: "Catalogs_Products");

            migrationBuilder.DropTable(
                name: "Customers_Pictures");

            migrationBuilder.DropTable(
                name: "LogsTools");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products_Pictures");

            migrationBuilder.DropTable(
                name: "Tools_Pictures");

            migrationBuilder.DropTable(
                name: "UsersPictures");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "BotCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
