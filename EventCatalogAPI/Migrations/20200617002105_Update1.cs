using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_ticket_hilo",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "EventTicketId",
                table: "CatalogEventItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEventItems_EventTicketId",
                table: "CatalogEventItems",
                column: "EventTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogEventItems_EventTickets_EventTicketId",
                table: "CatalogEventItems",
                column: "EventTicketId",
                principalTable: "EventTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogEventItems_EventTickets_EventTicketId",
                table: "CatalogEventItems");

            migrationBuilder.DropTable(
                name: "EventTickets");

            migrationBuilder.DropIndex(
                name: "IX_CatalogEventItems_EventTicketId",
                table: "CatalogEventItems");

            migrationBuilder.DropSequence(
                name: "event_ticket_hilo");

            migrationBuilder.DropColumn(
                name: "EventTicketId",
                table: "CatalogEventItems");
        }
    }
}
