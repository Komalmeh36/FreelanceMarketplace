using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freelanceMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Users_UserId",
                table: "Gigs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Gigs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Users_UserId",
                table: "Gigs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Users_UserId",
                table: "Gigs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Gigs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Users_UserId",
                table: "Gigs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
