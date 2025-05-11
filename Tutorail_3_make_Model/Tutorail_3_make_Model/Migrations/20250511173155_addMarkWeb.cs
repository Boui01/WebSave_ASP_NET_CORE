using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorail_3_make_Model.Migrations
{
    /// <inheritdoc />
    public partial class addMarkWeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "mark",
                table: "Webs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mark",
                table: "Webs");
        }
    }
}
