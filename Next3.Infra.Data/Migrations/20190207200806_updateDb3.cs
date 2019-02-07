using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Next3.Infra.Data.Migrations
{
    public partial class updateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expertise_Restaurant_RestaurantId",
                table: "Expertise");

            migrationBuilder.DropIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Expertise");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpertiseId",
                table: "Restaurant",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ExpertiseId",
                table: "Restaurant",
                column: "ExpertiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Expertise_ExpertiseId",
                table: "Restaurant",
                column: "ExpertiseId",
                principalTable: "Expertise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Expertise_ExpertiseId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ExpertiseId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ExpertiseId",
                table: "Restaurant");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Expertise",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Restaurant_RestaurantId",
                table: "Expertise",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
