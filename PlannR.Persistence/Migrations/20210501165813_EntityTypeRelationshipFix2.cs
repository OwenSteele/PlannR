using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PlannR.Persistence.Migrations
{
    public partial class EntityTypeRelationshipFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Events_AssociatedEventEventId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_AssociatedEventEventId",
                table: "RoutePoints");

            migrationBuilder.DropColumn(
                name: "AssociatedEventEventId",
                table: "RoutePoints");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "RoutePoints",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "RoutePoints");

            migrationBuilder.AddColumn<Guid>(
                name: "AssociatedEventEventId",
                table: "RoutePoints",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_AssociatedEventEventId",
                table: "RoutePoints",
                column: "AssociatedEventEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Events_AssociatedEventEventId",
                table: "RoutePoints",
                column: "AssociatedEventEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
