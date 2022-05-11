using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avaliacao_Atos.Data.Migrations
{
    public partial class insertdefaultuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"), "userdefault@atos.com", "User Default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"));
        }
    }
}
