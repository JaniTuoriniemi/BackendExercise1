using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendExercise.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Person",
                newName: "PersonIDnr");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Person",
                newName: "IDnr");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonID",
                table: "Person",
                newName: "IX_Person_PersonIDnr");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonIDnr",
                table: "Person",
                column: "PersonIDnr",
                principalTable: "Person",
                principalColumn: "IDnr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonIDnr",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "PersonIDnr",
                table: "Person",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "IDnr",
                table: "Person",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonIDnr",
                table: "Person",
                newName: "IX_Person_PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID");
        }
    }
}
