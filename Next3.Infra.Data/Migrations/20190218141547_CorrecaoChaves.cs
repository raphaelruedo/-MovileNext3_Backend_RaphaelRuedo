using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Next3.Infra.Data.Migrations
{
    public partial class CorrecaoChaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Restaurant_RestaurantId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_RestaurantId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Restaurant",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_AddressId",
                table: "Restaurant",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Address_AddressId",
                table: "Restaurant",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Address_AddressId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_AddressId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Restaurant");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Address",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_RestaurantId",
                table: "Address",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Restaurant_RestaurantId",
                table: "Address",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
