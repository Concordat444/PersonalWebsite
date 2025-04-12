using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebsite.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedProductOwnerKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductOwners_ProductOwnerOwnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductOwnerOwnerId",
                table: "Products",
                newName: "ProductOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductOwnerOwnerId",
                table: "Products",
                newName: "IX_Products_ProductOwnerId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ProductOwners",
                newName: "ProductOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductOwners_ProductOwnerId",
                table: "Products",
                column: "ProductOwnerId",
                principalTable: "ProductOwners",
                principalColumn: "ProductOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductOwners_ProductOwnerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductOwnerId",
                table: "Products",
                newName: "ProductOwnerOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductOwnerId",
                table: "Products",
                newName: "IX_Products_ProductOwnerOwnerId");

            migrationBuilder.RenameColumn(
                name: "ProductOwnerId",
                table: "ProductOwners",
                newName: "OwnerId");

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductOwners_ProductOwnerOwnerId",
                table: "Products",
                column: "ProductOwnerOwnerId",
                principalTable: "ProductOwners",
                principalColumn: "OwnerId");
        }
    }
}
