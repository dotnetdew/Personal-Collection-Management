using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class BookModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Books",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "Books",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80091b98-79dd-4d25-ab4c-9c3e5dac3bf7", "AQAAAAIAAYagAAAAEK2VDL2EZCEmnPQNtVD/lkxTRvk0MgVrdUsPX9UeP32xm/ibRQYd5q7+1qflnJCpqA==", "feb7874f-7196-40ed-ab4a-bbb0be1b81be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f7b31e2-dcde-41dc-a59e-2abddc9d1d4d", "AQAAAAIAAYagAAAAEOO5bsndhvEM0Vio8gvyWxk6KW/nUwKC3vro0R9KZPDsCvSmLgbw7n5BkkcS2IjfKQ==", "e13c6403-9d07-4005-9335-c8c4c2583285" });
        }
    }
}
