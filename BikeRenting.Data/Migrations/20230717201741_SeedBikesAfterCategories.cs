using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRenting.Data.Migrations
{
    public partial class SeedBikesAfterCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("1be65185-6408-465e-a6b6-774b3d615954"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("bbc139c9-8c6e-4a48-bb93-cb8301b0afdd"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("eb2ea088-9389-4249-8dfd-b6cc6634b1e6"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("1be65185-6408-465e-a6b6-774b3d615954"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("bbc139c9-8c6e-4a48-bb93-cb8301b0afdd"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("eb2ea088-9389-4249-8dfd-b6cc6634b1e6"));

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
    }
}
