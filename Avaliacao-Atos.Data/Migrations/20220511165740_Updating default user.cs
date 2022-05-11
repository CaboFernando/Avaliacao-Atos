using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avaliacao_Atos.Data.Migrations
{
    public partial class Updatingdefaultuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                column: "DateCreated",
                value: new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
