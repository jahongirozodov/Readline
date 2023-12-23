using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Readline.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Assets_AssetId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "AssetId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                table: "Books",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AssetId",
                table: "Books",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Assets_AssetId",
                table: "Books",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Assets_AssetId",
                table: "Users",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Assets_AssetId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Assets_AssetId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Books_AssetId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Books");

            migrationBuilder.AlterColumn<long>(
                name: "AssetId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Assets_AssetId",
                table: "Users",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
