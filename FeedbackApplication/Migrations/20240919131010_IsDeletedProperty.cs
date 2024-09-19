using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackApplication.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Opiniones",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Opiniones");
        }
    }
}
