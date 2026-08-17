using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalLab1.Migrations
{
    /// <inheritdoc />
    public partial class CgpaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cgpa",
                table: "Student",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cgpa",
                table: "Student");
        }
    }
}
