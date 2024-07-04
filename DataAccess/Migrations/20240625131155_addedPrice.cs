using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeklifVer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Definition" },
                values: new object[,]
                {
                    { 1, "Member" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "RoleId", "Surname" },
                values: new object[] { 1, "teknomanihah@gmail.com", "Hakan", "123", "5060407176", 2, "Yıldız" });
        }
    }
}
