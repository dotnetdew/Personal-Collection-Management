using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class CoinModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Coins",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Coins",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "936ec79e-26eb-43be-88e1-8864abad200f", "AQAAAAIAAYagAAAAEAGeWtTJExUMDpUZ5Z2i4P0KNVv5hTg3InlPp4j19vD1muyJV+W2iR2/bNyZW6+mVw==", "ee252ca3-3558-4a1a-8f98-255b49695d50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66516c7a-64c2-4372-ad18-d7cdce8f3b74", "AQAAAAIAAYagAAAAEJFxTkbK31WcrAsLuTOHUrObbGmj8r4fczt9GR3O7OEW7VF3tWEx9zFxzGUVD9LCoA==", "a1051060-b20b-4f37-90b1-2afb20d948ed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Coins");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "Coins",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdf985d7-7ecd-4cb9-a135-5e6b38886ac6", "AQAAAAIAAYagAAAAEE0bn8PA98V4Fh7AOdK4phaXGqanzjFviSqTVIcdx47rzxWz6jYZUlHkRF7yUMThAg==", "e14a8940-3da0-4e21-ba12-17178f1d2e2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "441c2f7f-62c6-4be9-b097-a87cc5002b47", "AQAAAAIAAYagAAAAEIzm5Ex36biwAlERzXurqOqRPxBKD5kUQ+VE4IJikv9Qw3XaRvLmOJ9WsQqc0dcVYQ==", "2c9f6ab6-c31e-4e4e-9c52-77fa995f29b7" });
        }
    }
}
