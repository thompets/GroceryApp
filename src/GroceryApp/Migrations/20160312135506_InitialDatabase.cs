using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace GroceryApp.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryCategory", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "GroceryStore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryStore", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "GroceryTrip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalSpent = table.Column<decimal>(nullable: false),
                    TripDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryTrip", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    GroceryTripId = table.Column<int>(nullable: true),
                    StoreId = table.Column<int>(nullable: true),
                    TotalSpent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stop_GroceryTrip_GroceryTripId",
                        column: x => x.GroceryTripId,
                        principalTable: "GroceryTrip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stop_GroceryStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "GroceryStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "StopCategoryTotal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    StopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopCategoryTotal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopCategoryTotal_GroceryCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GroceryCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StopCategoryTotal_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("StopCategoryTotal");
            migrationBuilder.DropTable("GroceryCategory");
            migrationBuilder.DropTable("Stop");
            migrationBuilder.DropTable("GroceryTrip");
            migrationBuilder.DropTable("GroceryStore");
        }
    }
}
