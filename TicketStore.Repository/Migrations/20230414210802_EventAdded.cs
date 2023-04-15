using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Repository.Migrations
{
    public partial class EventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "varchar(150)", nullable: false),
                    description = table.Column<string>(type: "varchar(max)", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    venue_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                    table.ForeignKey(
                        name: "FK_event_venue_venue_id",
                        column: x => x.venue_id,
                        principalTable: "venue",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_venue_id",
                table: "event",
                column: "venue_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");
        }
    }
}
