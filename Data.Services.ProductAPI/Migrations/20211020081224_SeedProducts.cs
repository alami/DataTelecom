using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Processors", "Processor quantity (Количество процессоров) ", "", "CPU", 15.0 },
                    { 2, "Memory", "Total memory (Gb) / Общее количество памяти ", "", "Memory", 13.99 },
                    { 3, "Disks", "Hard disk memory (Tb) / Память на жестких дисках", "", "HD", 10.99 },
                    { 4, "Disks", "SSD memory  (Tb) / Память на SSD", "", "SSD", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
