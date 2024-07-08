using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifVer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisings_Models_ModelId",
                table: "Advertisings");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Roles_RoleId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    AdvertisingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Advertisings_AdvertisingId",
                        column: x => x.AdvertisingId,
                        principalTable: "Advertisings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisings_MemberId",
                table: "Advertisings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AdvertisingId",
                table: "Offers",
                column: "AdvertisingId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MemberId",
                table: "Offers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisings_Members_MemberId",
                table: "Advertisings",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisings_Models_ModelId",
                table: "Advertisings",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Roles_RoleId",
                table: "Members",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisings_Members_MemberId",
                table: "Advertisings");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisings_Models_ModelId",
                table: "Advertisings");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Roles_RoleId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Advertisings_MemberId",
                table: "Advertisings");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisings_Models_ModelId",
                table: "Advertisings",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Roles_RoleId",
                table: "Members",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
