using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRenting.Data.Migrations
{
    public partial class AddIsActiveColumnInBikeEntityForSoftDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Bikes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("0f97070f-937a-47f9-b7be-61f3f63e0fce"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("a9bcaee5-b07b-4240-8a04-aca52a47ffc6"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("c9a29f07-5875-4789-871a-cd6d4951569c"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("0f97070f-937a-47f9-b7be-61f3f63e0fce"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("a9bcaee5-b07b-4240-8a04-aca52a47ffc6"));

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: new Guid("c9a29f07-5875-4789-871a-cd6d4951569c"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Bikes");

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("1be65185-6408-465e-a6b6-774b3d615954"), "Sokolska 6А, 9002 Varna Center, Varna", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.", "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1", 250.00m, null, "Apollo Valier Mens Mountain Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("bbc139c9-8c6e-4a48-bb93-cb8301b0afdd"), "Rue du Trône 129, 1050 Ixelles, Belgium", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable and capable of carrying heavy loads. Brand new.", "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg", 180.00m, null, "Trek 1120 Adventure Touring Bike" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("eb2ea088-9389-4249-8dfd-b6cc6634b1e6"), "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia", new Guid("abb45694-e4c3-4a7c-80f7-bb249ee975a1"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brand new road carbon bike. Very comfortable and fast.", "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp", 300.00m, new Guid("c6174679-b1ea-4627-832d-d666aa928aab"), "Twitter Gravel V2 RS24 ROAD CARBON BIKE" });
        }
    }
}
