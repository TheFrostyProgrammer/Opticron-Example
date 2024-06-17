using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opticron.Migrations
{
    /// <inheritdoc />
    public partial class SeedOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonName",
                table: "Offers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ButtonName",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
