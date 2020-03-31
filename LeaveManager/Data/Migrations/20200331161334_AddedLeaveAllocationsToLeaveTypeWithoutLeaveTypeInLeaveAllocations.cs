using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManager.Data.Migrations
{
    public partial class AddedLeaveAllocationsToLeaveTypeWithoutLeaveTypeInLeaveAllocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveAllocations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_LeaveTypeId",
                table: "LeaveAllocations",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllocations",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_LeaveTypeId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LeaveAllocations");
        }
    }
}
