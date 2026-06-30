using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreModelApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "Engineering" },
                    { 3, "Finance" },
                    { 4, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DepartmentID", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Rafael", new DateTime(2026, 6, 29, 23, 27, 57, 807, DateTimeKind.Local).AddTicks(7181), "Carvalho" },
                    { 2, 1, "Larissa", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9604), "Gomes" },
                    { 3, 2, "Maria", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9623), "Oliveira" },
                    { 4, 2, "Pedro", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9626), "Santos" },
                    { 5, 2, "Mariana", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9628), "Costa" },
                    { 6, 3, "João", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9629), "Silva" },
                    { 7, 4, "Beatriz", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9630), "Almeida" },
                    { 8, 4, "Gabriel", new DateTime(2026, 6, 29, 23, 27, 57, 809, DateTimeKind.Local).AddTicks(9631), "Rodrigues" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
