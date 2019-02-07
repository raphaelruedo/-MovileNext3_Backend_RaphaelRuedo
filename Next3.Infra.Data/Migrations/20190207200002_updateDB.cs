using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Next3.Infra.Data.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Restaurant_RestaurantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Address_AddressId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Expertise_ExpertiseId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_AddressId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ExpertiseId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Address_RestaurantId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ExpertiseId",
                table: "Restaurant");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Expertise",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise",
                column: "RestaurantId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Restaurant_RestaurantId",
                table: "Expertise",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Restaurant_RestaurantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Expertise_Restaurant_RestaurantId",
                table: "Expertise");

            migrationBuilder.DropIndex(
                name: "IX_Expertise_RestaurantId",
                table: "Expertise");

            migrationBuilder.DropIndex(
                name: "IX_Address_RestaurantId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Expertise");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Restaurant",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExpertiseId",
                table: "Restaurant",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_AddressId",
                table: "Restaurant",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ExpertiseId",
                table: "Restaurant",
                column: "ExpertiseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_RestaurantId",
                table: "Address",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Restaurant_RestaurantId",
                table: "Address",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Address_AddressId",
                table: "Restaurant",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Expertise_ExpertiseId",
                table: "Restaurant",
                column: "ExpertiseId",
                principalTable: "Expertise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
