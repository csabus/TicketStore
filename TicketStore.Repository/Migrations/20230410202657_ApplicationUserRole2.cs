using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Repository.Migrations
{
    public partial class ApplicationUserRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_role_user_id",
                table: "application_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_user_role_id",
                table: "application_user_role");

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_role_role_id",
                table: "application_user_role",
                column: "role_id",
                principalTable: "application_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_user_user_id",
                table: "application_user_role",
                column: "user_id",
                principalTable: "application_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_role_role_id",
                table: "application_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_user_user_id",
                table: "application_user_role");

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_role_user_id",
                table: "application_user_role",
                column: "user_id",
                principalTable: "application_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_user_role_id",
                table: "application_user_role",
                column: "role_id",
                principalTable: "application_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
