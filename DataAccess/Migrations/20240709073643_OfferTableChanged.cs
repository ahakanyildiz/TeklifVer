using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifVer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OfferTableChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offers");
        }
    }
}
