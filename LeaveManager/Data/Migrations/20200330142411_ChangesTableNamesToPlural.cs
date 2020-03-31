using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManager.Data.Migrations
{
    public partial class ChangesTableNamesToPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocation_AspNetUsers_EmployeeId",
                table: "LeaveAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocation_LeaveType_LeaveTypeId",
                table: "LeaveAllocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveAllocation",
                table: "LeaveAllocation");

            migrationBuilder.RenameTable(
                name: "LeaveType",
                newName: "LeaveTypes");

            migrationBuilder.RenameTable(
                name: "LeaveAllocation",
                newName: "LeaveAllocations");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllocation_LeaveTypeId",
                table: "LeaveAllocations",
                newName: "IX_LeaveAllocations_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllocation_EmployeeId",
                table: "LeaveAllocations",
                newName: "IX_LeaveAllocations_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveAllocations",
                table: "LeaveAllocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                table: "LeaveAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveAllocations",
                table: "LeaveAllocations");

            migrationBuilder.RenameTable(
                name: "LeaveTypes",
                newName: "LeaveType");

            migrationBuilder.RenameTable(
                name: "LeaveAllocations",
                newName: "LeaveAllocation");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllocations_LeaveTypeId",
                table: "LeaveAllocation",
                newName: "IX_LeaveAllocation_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocation",
                newName: "IX_LeaveAllocation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveAllocation",
                table: "LeaveAllocation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocation_AspNetUsers_EmployeeId",
                table: "LeaveAllocation",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocation_LeaveType_LeaveTypeId",
                table: "LeaveAllocation",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
