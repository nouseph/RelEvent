using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_event_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_event_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogEventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    EventHost = table.Column<string>(nullable: false),
                    CatalogEventCategoryId = table.Column<int>(nullable: false),
                    CatalogEventTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogEventItems_CatalogEventCategories_CatalogEventCategoryId",
                        column: x => x.CatalogEventCategoryId,
                        principalTable: "CatalogEventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEventItems_CatalogEventTypes_CatalogEventTypeId",
                        column: x => x.CatalogEventTypeId,
                        principalTable: "CatalogEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItems_CatalogEventCategoryId",
                table: "CatalogEventItems",
                column: "CatalogEventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItems_CatalogEventTypeId",
                table: "CatalogEventItems",
                column: "CatalogEventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogEventItems");

            migrationBuilder.DropTable(
                name: "CatalogEventCategories");

            migrationBuilder.DropTable(
                name: "CatalogEventTypes");

            migrationBuilder.DropSequence(
                name: "catalog_event_category_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_event_item_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_event_type_hilo");
        }
    }
}
