using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManager.Data.Migrations
{
    public partial class AddedEmployeeListTEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LeaveTypeId",
                table: "AspNetUsers",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LeaveTypes_LeaveTypeId",
                table: "AspNetUsers",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LeaveTypes_LeaveTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LeaveTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "AspNetUsers");
        }
    }
}
