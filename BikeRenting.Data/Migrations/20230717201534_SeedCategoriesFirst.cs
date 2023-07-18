using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRenting.Data.Migrations
{
    public partial class SeedCategoriesFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Agents_AgentId",
                table: "Bikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Categories_CategoryId",
                table: "Bikes");

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("3b68940d-11d7-45f2-b74e-3374055946bd"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("3bde0c4d-c62f-499a-8331-6d768f5da29f"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("9659809e-2621-43eb-84a1-c5dcebff7b63"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Bikes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Agents_AgentId",
                table: "Bikes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Categories_CategoryId",
                table: "Bikes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Agents_AgentId",
                table: "Bikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Categories_CategoryId",
                table: "Bikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Bikes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("3b68940d-11d7-45f2-b74e-3374055946bd"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("3bde0c4d-c62f-499a-8331-6d768f5da29f"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("9659809e-2621-43eb-84a1-c5dcebff7b63"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Agents_AgentId",
                table: "Bikes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Categories_CategoryId",
                table: "Bikes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
