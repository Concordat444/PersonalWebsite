using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebsite.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ProductOwners_ProductOwnerOwnerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ProductOwnerOwnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ProductOwnerOwnerId",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductOwnerOwnerId",
                table: "Games",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProductOwnerOwnerId",
                table: "Games",
                column: "ProductOwnerOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ProductOwners_ProductOwnerOwnerId",
                table: "Games",
                column: "ProductOwnerOwnerId",
                principalTable: "ProductOwners",
                principalColumn: "OwnerId");
        }
    }
}
