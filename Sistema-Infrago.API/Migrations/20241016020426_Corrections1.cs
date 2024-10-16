using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Infrago.API.Migrations
{
    /// <inheritdoc />
    public partial class Corrections1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceType",
                table: "MaintenanceDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaintenanceType",
                table: "MaintenanceDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
