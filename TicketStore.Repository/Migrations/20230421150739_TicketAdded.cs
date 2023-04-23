using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Repository.Migrations
{
    public partial class TicketAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<decimal>(type: "NUMERIC(38,17)", nullable: false),
                    is_available = table.Column<bool>(type: "BIT", nullable: false),
                    event_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticket_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ticket_ticket_type_type_id",
                        column: x => x.type_id,
                        principalTable: "ticket_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ticket_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_status", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "ticket_status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 10, "Available" },
                    { 20, "Reserved" },
                    { 30, "Sold" },
                    { 40, "Revoked" },
                    { 50, "Used" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ticket_event_id",
                table: "ticket",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_type_id",
                table: "ticket",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "ticket_status");
        }
    }
}
