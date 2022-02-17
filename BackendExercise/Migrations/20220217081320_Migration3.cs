using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendExercise.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonIDnr",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonIDnr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonIDnr",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonIDnr",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonIDnr",
                table: "Person",
                column: "PersonIDnr");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonIDnr",
                table: "Person",
                column: "PersonIDnr",
                principalTable: "Person",
                principalColumn: "IDnr");
        }
    }
}
