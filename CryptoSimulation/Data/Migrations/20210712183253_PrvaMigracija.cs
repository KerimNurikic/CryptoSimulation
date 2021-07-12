using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoSimulation.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    PortfolioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.PortfolioID);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WalletID = table.Column<int>(type: "int", nullable: false),
                    PortfolioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Portfolio_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Wallet_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletIDSender = table.Column<int>(type: "int", nullable: true),
                    WalletIDReciever = table.Column<int>(type: "int", nullable: false),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Portfolio_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Wallet_WalletIDReciever",
                        column: x => x.WalletIDReciever,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Wallet_WalletIDSender",
                        column: x => x.WalletIDSender,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletPart",
                columns: table => new
                {
                    WalletPartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletID = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletPart", x => x.WalletPartID);
                    table.ForeignKey(
                        name: "FK_WalletPart_Wallet_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_PortfolioID",
                table: "ApplicationUser",
                column: "PortfolioID",
                unique: true,
                filter: "[PortfolioID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_WalletID",
                table: "ApplicationUser",
                column: "WalletID",
                unique: true,
                filter: "[WalletID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PortfolioID",
                table: "Transaction",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WalletIDReciever",
                table: "Transaction",
                column: "WalletIDReciever");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WalletIDSender",
                table: "Transaction",
                column: "WalletIDSender");

            migrationBuilder.CreateIndex(
                name: "IX_WalletPart_WalletID",
                table: "WalletPart",
                column: "WalletID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "WalletPart");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}
