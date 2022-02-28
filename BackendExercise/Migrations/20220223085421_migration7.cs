using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendExercise.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

           // migrationBuilder.DeleteData(
             //   table: "Person",
               // keyColumn: "IDnr",
                //keyValue: -2);

           // migrationBuilder.DeleteData(
             //   table: "Person",
               // keyColumn: "IDnr",
               // keyValue: -1);

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Person",
                newName: "CityName");

            migrationBuilder.DropColumn(
                name: "IDnr",
                table: "Person"
                );






            migrationBuilder.AddColumn<int>(name: "CityID",
                table: "Person",
                type: "int",
                 nullable: false,
                defaultValue: 0)
                 //.Annotation("SqlServer:Identity", "1, 1")
                ;

           

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonID");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Countryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Countryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "Countryname" },
                values: new object[] { -1, "Sweden" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName", "CountryID", "Countryname" },
                values: new object[] { -2, "Stockholm", -1, "Sweden" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName", "CountryID", "Countryname" },
                values: new object[] { -1, "Göteborg", -1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "CityID", "CityName", "Name", "Phone" },
                values: new object[] { -2, -2, "Stockholm", "Fredrik", 12345 });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "CityID", "CityName", "Name", "Phone" },
                values: new object[] { -1, -1, "Göteborg", "Bosse", 54321 });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityID",
                table: "Person",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_City_CityID",
                table: "Person",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_City_CityID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CityID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Person",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Person",
                newName: "IDnr");

            migrationBuilder.AlterColumn<int>(
                name: "IDnr",
                table: "Person",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "IDnr");
        }
    }
}
