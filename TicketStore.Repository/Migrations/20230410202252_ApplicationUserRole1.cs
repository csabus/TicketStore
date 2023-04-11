using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketStore.Repository.Migrations
{
    public partial class ApplicationUserRole1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_role_usert_id",
                table: "application_user_role");

            migrationBuilder.RenameColumn(
                name: "usert_id",
                table: "application_user_role",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_application_user_role_usert_id",
                table: "application_user_role",
                newName: "IX_application_user_role_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_role_user_id",
                table: "application_user_role",
                column: "user_id",
                principalTable: "application_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_user_role_application_role_user_id",
                table: "application_user_role");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "application_user_role",
                newName: "usert_id");

            migrationBuilder.RenameIndex(
                name: "IX_application_user_role_user_id",
                table: "application_user_role",
                newName: "IX_application_user_role_usert_id");

            migrationBuilder.AddForeignKey(
                name: "FK_application_user_role_application_role_usert_id",
                table: "application_user_role",
                column: "usert_id",
                principalTable: "application_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
