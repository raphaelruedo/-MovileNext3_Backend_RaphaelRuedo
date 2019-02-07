using Microsoft.EntityFrameworkCore.Migrations;

namespace Next3.Infra.Data.Migrations
{
    public partial class updateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise");

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise");

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise",
                column: "RestaurantId",
                unique: true);
        }
    }
}
