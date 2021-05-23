using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannR.Persistence.Migrations
{
    public partial class LocationsNotReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Locations_EndLocationLocationId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Locations_StartLocationLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_EndLocationLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_StartLocationLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_LocationId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Accomodations_LocationId",
                table: "Accomodations");

            migrationBuilder.RenameColumn(
                name: "StartLocationLocationId",
                table: "Transports",
                newName: "StartLocationId");

            migrationBuilder.RenameColumn(
                name: "EndLocationLocationId",
                table: "Transports",
                newName: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_EndLocationId",
                table: "Transports",
                column: "EndLocationId",
                unique: true,
                filter: "[EndLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_StartLocationId",
                table: "Transports",
                column: "StartLocationId",
                unique: true,
                filter: "[StartLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_LocationId",
                table: "RoutePoints",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accomodations_LocationId",
                table: "Accomodations",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Locations_EndLocationId",
                table: "Transports",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Locations_StartLocationId",
                table: "Transports",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Locations_EndLocationId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Locations_StartLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_EndLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_StartLocationId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_LocationId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Accomodations_LocationId",
                table: "Accomodations");

            migrationBuilder.RenameColumn(
                name: "StartLocationId",
                table: "Transports",
                newName: "StartLocationLocationId");

            migrationBuilder.RenameColumn(
                name: "EndLocationId",
                table: "Transports",
                newName: "EndLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_EndLocationLocationId",
                table: "Transports",
                column: "EndLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_StartLocationLocationId",
                table: "Transports",
                column: "StartLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_LocationId",
                table: "RoutePoints",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accomodations_LocationId",
                table: "Accomodations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Locations_EndLocationLocationId",
                table: "Transports",
                column: "EndLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Locations_StartLocationLocationId",
                table: "Transports",
                column: "StartLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
