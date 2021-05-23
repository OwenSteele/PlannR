using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PlannR.Persistence.Migrations
{
    public partial class TripLocationIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips");

            migrationBuilder.AlterColumn<Guid>(
                name: "StartLocationId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EndLocationId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips",
                column: "EndLocationId",
                unique: true,
                filter: "[EndLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips",
                column: "StartLocationId",
                unique: true,
                filter: "[StartLocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips");

            migrationBuilder.AlterColumn<Guid>(
                name: "StartLocationId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EndLocationId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips",
                column: "EndLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips",
                column: "StartLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
