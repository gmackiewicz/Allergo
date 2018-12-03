using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Allergo.Data.Migrations
{
    public partial class initialroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"), "3ca04c41-6ba2-41b4-8549-98e09c83777f", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5ec55e49-85fa-407c-a308-4faaec25ded0"), "5ec55e49-85fa-407c-a308-4faaec25ded0", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("275b3afd-e537-4e98-9d67-622b37606565"), "275b3afd-e537-4e98-9d67-622b37606565", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("275b3afd-e537-4e98-9d67-622b37606565"), "275b3afd-e537-4e98-9d67-622b37606565" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"), "3ca04c41-6ba2-41b4-8549-98e09c83777f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("5ec55e49-85fa-407c-a308-4faaec25ded0"), "5ec55e49-85fa-407c-a308-4faaec25ded0" });
        }
    }
}
