using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccountNumber", "Age", "Name" },
                values: new object[] { new Guid("42b1b5df-b595-4ded-86d4-30c69a15951d"), "123-3452134543-32", 30, "Jil" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccountNumber", "Age", "Name" },
                values: new object[] { new Guid("eef5a6c2-2e76-430d-b9ee-2123d71d9862"), "123-9384613085-55", 28, "Kevin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
