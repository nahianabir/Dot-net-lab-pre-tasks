using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalLab1.Migrations
{
    /// <inheritdoc />
    public partial class deptRltn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentID",
                table: "Student",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentID",
                table: "Student",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentID",
                table: "Student");
        }
    }
}
