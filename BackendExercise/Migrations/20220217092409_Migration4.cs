using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendExercise.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IDnr", "City", "Name", "Phone" },
                values: new object[] { -2, "Stockholm", "Fredrik", 12345 });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IDnr", "City", "Name", "Phone" },
                values: new object[] { -1, "Göteborg", "Bosse", 54321 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "IDnr",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "IDnr",
                keyValue: -1);
        }
    }
}
