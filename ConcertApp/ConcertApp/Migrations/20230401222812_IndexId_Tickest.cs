using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertApp.Migrations
{
    /// <inheritdoc />
    public partial class IndexId_Tickest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id",
                table: "Tickets",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_Id",
                table: "Tickets");
        }
    }
}
