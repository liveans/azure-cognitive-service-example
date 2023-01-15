using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureHomeworkProject.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISOName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISOName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Comments");
        }
    }
}
