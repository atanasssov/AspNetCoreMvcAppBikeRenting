using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRenting.Data.Migrations
{
    public partial class AddCreatedOnColumnToBikeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("22867897-0e9c-4230-bf0e-44ac8986e7f4"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("7c5e55da-f5b4-4299-94ad-06d000a03ae7"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("ae208f9f-72e5-455c-8fc6-7db268ebea11"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Bikes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("1d175eb0-56da-41b9-8857-0f79d22f1bd3"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("255dce7f-054f-4332-909e-e59bbf2a8962"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("c2a8a5a1-1f6d-4aad-a5e0-c2cc30332235"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("1d175eb0-56da-41b9-8857-0f79d22f1bd3"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("255dce7f-054f-4332-909e-e59bbf2a8962"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("c2a8a5a1-1f6d-4aad-a5e0-c2cc30332235"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Bikes");

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("22867897-0e9c-4230-bf0e-44ac8986e7f4"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("7c5e55da-f5b4-4299-94ad-06d000a03ae7"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("ae208f9f-72e5-455c-8fc6-7db268ebea11"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });
        }
    }
}
