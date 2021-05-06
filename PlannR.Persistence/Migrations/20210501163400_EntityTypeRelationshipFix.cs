using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PlannR.Persistence.Migrations
{
    public partial class EntityTypeRelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationTypes_AccomodationTypeId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeId",
                table: "Transports");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransportTypes",
                newName: "TransportTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventTypes",
                newName: "EventTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccomodationTypes",
                newName: "AccomodationTypeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransportTypeId",
                table: "Transports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventTypeId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccomodationTypeId",
                table: "Accomodations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationTypes_AccomodationTypeId",
                table: "Accomodations",
                column: "AccomodationTypeId",
                principalTable: "AccomodationTypes",
                principalColumn: "AccomodationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "EventTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeId",
                table: "Transports",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "TransportTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodations_AccomodationTypes_AccomodationTypeId",
                table: "Accomodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeId",
                table: "Transports");

            migrationBuilder.RenameColumn(
                name: "TransportTypeId",
                table: "TransportTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "EventTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccomodationTypeId",
                table: "AccomodationTypes",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransportTypeId",
                table: "Transports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventTypeId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccomodationTypeId",
                table: "Accomodations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodations_AccomodationTypes_AccomodationTypeId",
                table: "Accomodations",
                column: "AccomodationTypeId",
                principalTable: "AccomodationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportTypes_TransportTypeId",
                table: "Transports",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
