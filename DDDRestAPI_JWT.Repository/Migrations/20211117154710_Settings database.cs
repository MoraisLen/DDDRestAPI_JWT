using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDRestAPI_JWT.Repository.Migrations
{
    public partial class Settingsdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAPIs",
                table: "ClientAPIs");

            migrationBuilder.RenameTable(
                name: "ClientAPIs",
                newName: "ClientAPI");

            migrationBuilder.AlterColumn<string>(
                name: "Secret",
                table: "ClientAPI",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ClientAPI",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameId",
                table: "ClientAPI",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAPI",
                table: "ClientAPI",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAPI",
                table: "ClientAPI");

            migrationBuilder.RenameTable(
                name: "ClientAPI",
                newName: "ClientAPIs");

            migrationBuilder.AlterColumn<string>(
                name: "Secret",
                table: "ClientAPIs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ClientAPIs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "NameId",
                table: "ClientAPIs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAPIs",
                table: "ClientAPIs",
                column: "Id");
        }
    }
}