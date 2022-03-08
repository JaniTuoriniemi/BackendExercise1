using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendExercise.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: -2);

          //  migrationBuilder.AlterColumn<int>(
           //     name: "PersonID",
          //      table: "Person",
          //      type: "int",
            //    nullable: false,
           //     oldClrType: typeof(int),
           //     oldType: "int")
           //     .OldAnnotation("SqlServer:Identity", "1, 1");

          //  migrationBuilder.AlterColumn<int>(
          //      name: "CountryID",
          //      table: "Country",
          //      type: "int",
          //      nullable: false,
          //      oldClrType: typeof(int),
          //      oldType: "int")
          //      .OldAnnotation("SqlServer:Identity", "1, 1");

           // migrationBuilder.AlterColumn<int>(
           //     name: "CityID",
           //     table: "City",
           //     type: "int",
           //     nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    Languagename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguagesLanguageID = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguagesLanguageID, x.PersonsPersonID });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Language_LanguagesLanguageID",
                        column: x => x.LanguagesLanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Person_PersonsPersonID",
                        column: x => x.PersonsPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityID",
                keyValue: -2,
                column: "CityName",
                value: "Göteborg");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityID",
                keyValue: -1,
                column: "CityName",
                value: "Stockholm");

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageID", "Languagename" },
                values: new object[] { -2, "Swedish" });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: -1,
                columns: new[] { "CityName", "Name", "Phone" },
                values: new object[] { "Stockholm", "Fredrik", 12345 });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PersonsPersonID",
                table: "LanguagePerson",
                column: "PersonsPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Person",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Country",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "City",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityID",
                keyValue: -2,
                column: "CityName",
                value: "Stockholm");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityID",
                keyValue: -1,
                column: "CityName",
                value: "Göteborg");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: -1,
                columns: new[] { "CityName", "Name", "Phone" },
                values: new object[] { "Göteborg", "Bosse", 54321 });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "CityID", "CityName", "Name", "Phone" },
                values: new object[] { -2, -2, "Stockholm", "Fredrik", 12345 });
        }
    }
}
