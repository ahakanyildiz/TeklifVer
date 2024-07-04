using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifVer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedDefinitionOnCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Definition",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Definition",
                table: "Cars");
        }
    }
}
