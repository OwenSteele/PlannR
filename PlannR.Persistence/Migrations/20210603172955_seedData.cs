using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannR.Persistence.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccomodationTypes",
                columns: new[] { "AccomodationTypeId", "CreatedBy", "CreationDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("7648f662-e3c9-4e92-a33e-48a46c361679"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hotel" },
                    { new Guid("999e4496-0cba-4142-bed4-bad5fe73c54c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hostel" },
                    { new Guid("e36e5075-8593-4090-b636-03d0266a5dbf"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Camping" },
                    { new Guid("5148e821-5744-4e2c-ba3e-6717fd76272a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AirBnB" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "CreatedBy", "CreationDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("48b9dfb5-af95-48ff-956d-8306c8e06361"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sightseeing" },
                    { new Guid("6d9bdd96-3983-46f8-8605-deb42b781e7a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Concert" },
                    { new Guid("c680cdc8-a192-443a-955b-9c9b8b7eea1a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Meeting" },
                    { new Guid("40ba7966-82ba-49b9-a7a7-c2d6d48e8c6c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sporting event" },
                    { new Guid("67e04e6a-9255-4ab7-97f1-329b8691eca9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Party" },
                    { new Guid("8aad00ac-386e-4bac-80a3-8e6060925699"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Birthday" },
                    { new Guid("c08e6a5a-51fe-47b8-9c3f-80b0e9125aa1"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dinner" },
                    { new Guid("973e695f-1457-451e-91e9-cc1ae304c6f2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lunch" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "AltitudeInMetres", "CreatedBy", "CreationDate", "LastModifiedBy", "LastModifiedDate", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { new Guid("ec2d23b5-ce63-49de-8d0d-2f50dbdf63db"), "Rue Costes et Bellonte, 06206 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.660675787609719, 7.2145239508615173, "Nice Cote d'Azur Airport" },
                    { new Guid("d4ea4e13-d37c-4f93-81ad-899fc0b75409"), "3 Pl. Rossetti, 06300 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.697103296196026, 7.2759387247896905, "Cath�drale Sainte-R�parate de Nice" },
                    { new Guid("4a3385bf-537b-44ea-be30-9f626aa5a63d"), "2-16 Avenue de Verdun, 06000 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.695697722830552, 7.2679464761047363, "Jardin Albert 1er" },
                    { new Guid("4dd719de-44e2-4a5b-95f7-87129f30f399"), "65 Rue de France, 06000 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.695606899282765, 7.2590205915007919, "Villa Mass�na Mus�e" },
                    { new Guid("831dae8e-9866-482b-8f93-08e5066fd992"), "Avenue Nicolas II, 06000 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.703686541212491, 7.2534398669683746, "St Nicholas Russian Orthodox Cathedral" },
                    { new Guid("5a3613aa-3a39-44fd-9294-8f59f23b87be"), "37 Prom. des Anglais, 06000 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.694572199588656, 7.2577979809371778, "La Rotonde Nice" },
                    { new Guid("836776dd-b072-47f0-ab41-db806be82eb4"), "Avenue Thiers, 06008 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.704857352503517, 7.2615237793972414, "Nice-Ville" },
                    { new Guid("98e11885-fb8e-41f9-958b-ea5f4dea54d5"), "06200 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.66884420834225, 7.2111980132427815, "Grand Arenas Train Station" },
                    { new Guid("429d2829-eeb9-4803-aa8b-475811284232"), "Heathrow Airport Terminal 5, Longford TW6 2GW", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 51.47172252094142, -0.48761302520656669, "Heathrow Airport" },
                    { new Guid("3cb658dd-8d38-46ed-b998-88a49324b309"), "Place Wilson, 06230 Villefranche-sur-Mer, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.702579439477162, 7.3120155646662974, "Mayssa Beach Restaurant" },
                    { new Guid("0934b953-fb1f-42b9-81ae-62a614ee1826"), "London W8 4PY", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 51.505580999999999, -0.187664, "Home - Kensington" },
                    { new Guid("57f62afa-0861-4070-8f11-d9e1a0f2a994"), "Chemin du Fort du Mont Alban, 06000 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.701361486241971, 7.3000138371561558, "Fort du Mont Alban" },
                    { new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"), "1 Prom. des Anglais, 06046 Nice, France", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43.695451191777302, 7.265805593662451, "Le Meridien Nice" }
                });

            migrationBuilder.InsertData(
                table: "TransportTypes",
                columns: new[] { "TransportTypeId", "CreatedBy", "CreationDate", "HasFixedRoute", "IsPublic", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("b0ce54b5-e4fb-4870-9343-4346da5be65d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Plane" },
                    { new Guid("e23eb33a-a49e-4050-a4f2-0d693b7db5c4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Bicycle" },
                    { new Guid("7e2d7cde-75a8-4c15-ac90-2c8bc113cad2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Taxi" },
                    { new Guid("c5f6bfcf-fe9f-43f4-9096-11f3579d4d9a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Walking" },
                    { new Guid("a7538091-e359-497b-a780-9e1352ad515b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Train" },
                    { new Guid("0516b31f-3bdc-4d1d-b8d0-f562bb63bb81"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Bus" },
                    { new Guid("77e7da2d-d1d1-4c3b-ab8f-97496873fe38"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Car" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "CreatedBy", "CreationDate", "Description", "EndDateTime", "EndLocationId", "LastModifiedBy", "LastModifiedDate", "Name", "StartDateTime", "StartLocationId" },
                values: new object[] { new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "(Sample Trip) A trip to Nice for my birthday, with Emma and Brandon", new DateTime(2022, 6, 19, 21, 30, 0, 0, DateTimeKind.Unspecified), new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"), null, null, "Birthday trip to Nice!", new DateTime(2022, 6, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0934b953-fb1f-42b9-81ae-62a614ee1826") });

            migrationBuilder.InsertData(
                table: "Accomodations",
                columns: new[] { "AccomodationId", "AccomodationTypeId", "CostPerNight", "CreatedBy", "CreationDate", "Description", "EndDateTime", "LastModifiedBy", "LastModifiedDate", "LocationId", "Name", "Nights", "Rooms", "StartDateTime", "TripId" },
                values: new object[] { new Guid("f20529ca-7888-4967-84d0-044b1dfaf984"), new Guid("7648f662-e3c9-4e92-a33e-48a46c361679"), 192m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel for the trip, in Nice on the beach", new DateTime(2022, 6, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"), "Le Meridien Hotel", 8, 2, new DateTime(2022, 6, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CompanyName", "CreatedBy", "CreationDate", "Description", "EmailReminderEnabled", "EmailReminderTimer", "EndDateTime", "EventTypeId", "LastModifiedBy", "LastModifiedDate", "LocationId", "Name", "StartDateTime", "TripId" },
                values: new object[,]
                {
                    { new Guid("578adb0d-7183-4e65-8ed7-f69230fef64e"), "La Rotonde", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birthday dinner!", false, null, new DateTime(2022, 6, 11, 22, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c08e6a5a-51fe-47b8-9c3f-80b0e9125aa1"), null, null, new Guid("5a3613aa-3a39-44fd-9294-8f59f23b87be"), "Dinner at La Rotonde", new DateTime(2022, 6, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") },
                    { new Guid("fabb3e78-7161-483b-93cc-7dd34516136d"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit to an amazing cathedral in east Nice", false, null, new DateTime(2022, 6, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("48b9dfb5-af95-48ff-956d-8306c8e06361"), null, null, new Guid("831dae8e-9866-482b-8f93-08e5066fd992"), "Visit Cath�drale Saint-Nicolas de Nice", new DateTime(2022, 6, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") },
                    { new Guid("a3dc5619-ace9-4609-8684-679d929e0621"), "Mayssa Beach", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Late lunch on the shoreline, during our explore", false, null, new DateTime(2022, 6, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("973e695f-1457-451e-91e9-cc1ae304c6f2"), null, null, new Guid("3cb658dd-8d38-46ed-b998-88a49324b309"), "Lunch at Mayssa Beach", new DateTime(2022, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "CreatedBy", "CreationDate", "EndDateTime", "LastModifiedBy", "LastModifiedDate", "Name", "StartDateTime", "TripId" },
                values: new object[] { new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 18, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tour De Nice!", new DateTime(2022, 6, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "TransportId", "CreatedBy", "CreationDate", "Description", "EndDateTime", "EndLocationId", "LastModifiedBy", "LastModifiedDate", "Name", "StartDateTime", "StartLocationId", "TransportTypeId", "TripId" },
                values: new object[,]
                {
                    { new Guid("5417554a-8220-450e-b357-52456334f1fc"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taxi with a black cab to Heathrow", new DateTime(2022, 6, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new Guid("429d2829-eeb9-4803-aa8b-475811284232"), null, null, "Taxi to the airport", new DateTime(2022, 6, 10, 17, 15, 0, 0, DateTimeKind.Unspecified), new Guid("0934b953-fb1f-42b9-81ae-62a614ee1826"), new Guid("7e2d7cde-75a8-4c15-ac90-2c8bc113cad2"), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") },
                    { new Guid("8273da23-c6d6-411a-9a2a-79c48ba32b51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flight BA 354 LHR - NCE", new DateTime(2022, 6, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec2d23b5-ce63-49de-8d0d-2f50dbdf63db"), null, null, "Flight Heathrow to Nice", new DateTime(2022, 6, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), new Guid("429d2829-eeb9-4803-aa8b-475811284232"), new Guid("b0ce54b5-e4fb-4870-9343-4346da5be65d"), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") },
                    { new Guid("aa7a8f38-a9fa-4d86-a762-39e724ee4a83"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local train from Nice airport thats runs into nice town centre.", new DateTime(2022, 6, 10, 23, 30, 0, 0, DateTimeKind.Unspecified), new Guid("836776dd-b072-47f0-ab41-db806be82eb4"), null, null, "Train from the airport to the hotel", new DateTime(2022, 6, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98e11885-fb8e-41f9-958b-ea5f4dea54d5"), new Guid("a7538091-e359-497b-a780-9e1352ad515b"), new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d") }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "AccomodationId", "Comments", "Cost", "CreatedBy", "CreationDate", "Discriminator", "Email", "LastModifiedBy", "LastModifiedDate", "Link", "Name" },
                values: new object[] { new Guid("dceab942-149b-49a0-bb48-25992581b529"), new Guid("f20529ca-7888-4967-84d0-044b1dfaf984"), "Booking for 8 nights, 2 rooms", 3072m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AccomodationBooking", null, null, null, "www.marriott.com/hotels/travel/ncemd-le-m%C3%A9ridien-nice/?scid=bb1a189a-fec3-4d19-a255-54ba596febe2&y_source=1_Mjc4MjIwOC03MTUtbG9jYXRpb24uZ29vZ2xlX3dlYnNpdGVfb3ZlcnJpZGU%3D", "Le Meridien Nice Room Reservations" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "Comments", "Cost", "CreatedBy", "CreationDate", "Discriminator", "Email", "EventId", "LastModifiedBy", "LastModifiedDate", "Link", "Name" },
                values: new object[] { new Guid("71177157-3a7c-4b6b-a428-02de1f1a92e3"), "Deposit for my birthday dinner", 10m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EventBooking", "la-rotonde-brasserie@hotel-negresco-nice.com", new Guid("578adb0d-7183-4e65-8ed7-f69230fef64e"), null, null, "https://www.hotel-negresco-nice.com/sites/default/files/2021-05/MENU-Rotonde-20052021.pdf", "La Rotonde Reservation" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "Comments", "Cost", "CreatedBy", "CreationDate", "Discriminator", "Email", "LastModifiedBy", "LastModifiedDate", "Link", "Name", "TransportId" },
                values: new object[] { new Guid("469504cd-0f4f-4157-b6ee-b8da3f8cb9ed"), "Tickets for Me, Brandon and Emma to fly to Nice", 312m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TransportBooking", "bookings@ba.com", null, null, "www.britishairways.com/en-gb/destinations/nice/flights-to-nice", "BA Tickets BA 354 x 3", new Guid("8273da23-c6d6-411a-9a2a-79c48ba32b51") });

            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "EndDateTime", "EventId", "LastModifiedBy", "LastModifiedDate", "LocationId", "RouteId", "StartDateTime" },
                values: new object[,]
                {
                    { new Guid("a8188dd6-33b2-4f07-96e2-1178ba21503d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92187c3d-db6b-44f7-8ab4-294ec4766916"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("4dd719de-44e2-4a5b-95f7-87129f30f399"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db097829-352b-4146-a80f-e31b019f2513"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("4a3385bf-537b-44ea-be30-9f626aa5a63d"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 11, 15, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d721c9af-c204-44c6-8edf-0b75d24715ed"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("d4ea4e13-d37c-4f93-81ad-899fc0b75409"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77066f35-f487-43e6-bd0d-ab4df183afd3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("57f62afa-0861-4070-8f11-d9e1a0f2a994"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0bb95d0-b208-456a-826f-84da54601d0a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3dc5619-ace9-4609-8684-679d929e0621"), null, null, new Guid("3cb658dd-8d38-46ed-b998-88a49324b309"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13c427f4-abcf-48ac-a3da-c8f0ff5f4439"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 18, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"), new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"), new DateTime(2022, 6, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccomodationTypes",
                keyColumn: "AccomodationTypeId",
                keyValue: new Guid("5148e821-5744-4e2c-ba3e-6717fd76272a"));

            migrationBuilder.DeleteData(
                table: "AccomodationTypes",
                keyColumn: "AccomodationTypeId",
                keyValue: new Guid("999e4496-0cba-4142-bed4-bad5fe73c54c"));

            migrationBuilder.DeleteData(
                table: "AccomodationTypes",
                keyColumn: "AccomodationTypeId",
                keyValue: new Guid("e36e5075-8593-4090-b636-03d0266a5dbf"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("dceab942-149b-49a0-bb48-25992581b529"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("71177157-3a7c-4b6b-a428-02de1f1a92e3"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("469504cd-0f4f-4157-b6ee-b8da3f8cb9ed"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("40ba7966-82ba-49b9-a7a7-c2d6d48e8c6c"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("67e04e6a-9255-4ab7-97f1-329b8691eca9"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("6d9bdd96-3983-46f8-8605-deb42b781e7a"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("8aad00ac-386e-4bac-80a3-8e6060925699"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("c680cdc8-a192-443a-955b-9c9b8b7eea1a"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("fabb3e78-7161-483b-93cc-7dd34516136d"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("13c427f4-abcf-48ac-a3da-c8f0ff5f4439"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("77066f35-f487-43e6-bd0d-ab4df183afd3"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("92187c3d-db6b-44f7-8ab4-294ec4766916"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("a8188dd6-33b2-4f07-96e2-1178ba21503d"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("d0bb95d0-b208-456a-826f-84da54601d0a"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("d721c9af-c204-44c6-8edf-0b75d24715ed"));

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: new Guid("db097829-352b-4146-a80f-e31b019f2513"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("0516b31f-3bdc-4d1d-b8d0-f562bb63bb81"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("77e7da2d-d1d1-4c3b-ab8f-97496873fe38"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("c5f6bfcf-fe9f-43f4-9096-11f3579d4d9a"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("e23eb33a-a49e-4050-a4f2-0d693b7db5c4"));

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "TransportId",
                keyValue: new Guid("5417554a-8220-450e-b357-52456334f1fc"));

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "TransportId",
                keyValue: new Guid("aa7a8f38-a9fa-4d86-a762-39e724ee4a83"));

            migrationBuilder.DeleteData(
                table: "Accomodations",
                keyColumn: "AccomodationId",
                keyValue: new Guid("f20529ca-7888-4967-84d0-044b1dfaf984"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("48b9dfb5-af95-48ff-956d-8306c8e06361"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("578adb0d-7183-4e65-8ed7-f69230fef64e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("a3dc5619-ace9-4609-8684-679d929e0621"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("4a3385bf-537b-44ea-be30-9f626aa5a63d"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("4dd719de-44e2-4a5b-95f7-87129f30f399"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("57f62afa-0861-4070-8f11-d9e1a0f2a994"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("831dae8e-9866-482b-8f93-08e5066fd992"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("836776dd-b072-47f0-ab41-db806be82eb4"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("98e11885-fb8e-41f9-958b-ea5f4dea54d5"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d4ea4e13-d37c-4f93-81ad-899fc0b75409"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: new Guid("5c71abe1-23bf-492b-bba9-3b60c50c1576"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("7e2d7cde-75a8-4c15-ac90-2c8bc113cad2"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("a7538091-e359-497b-a780-9e1352ad515b"));

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "TransportId",
                keyValue: new Guid("8273da23-c6d6-411a-9a2a-79c48ba32b51"));

            migrationBuilder.DeleteData(
                table: "AccomodationTypes",
                keyColumn: "AccomodationTypeId",
                keyValue: new Guid("7648f662-e3c9-4e92-a33e-48a46c361679"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("973e695f-1457-451e-91e9-cc1ae304c6f2"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "EventTypeId",
                keyValue: new Guid("c08e6a5a-51fe-47b8-9c3f-80b0e9125aa1"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("3cb658dd-8d38-46ed-b998-88a49324b309"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("429d2829-eeb9-4803-aa8b-475811284232"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("5a3613aa-3a39-44fd-9294-8f59f23b87be"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("ec2d23b5-ce63-49de-8d0d-2f50dbdf63db"));

            migrationBuilder.DeleteData(
                table: "TransportTypes",
                keyColumn: "TransportTypeId",
                keyValue: new Guid("b0ce54b5-e4fb-4870-9343-4346da5be65d"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: new Guid("eb5c9c56-56ef-4b59-9a5f-34b3fd25240d"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("0934b953-fb1f-42b9-81ae-62a614ee1826"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("3a7412f5-1c27-4993-98e2-f36de88871c5"));
        }
    }
}
