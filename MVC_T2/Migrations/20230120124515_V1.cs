using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCT2.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    SupervisorSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorSSN",
                        column: x => x.SupervisorSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLocation",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeptNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocation", x => new { x.DeptNumber, x.Location });
                    table.ForeignKey(
                        name: "FK_DepartmentLocation_Departments_DeptNumber",
                        column: x => x.DeptNumber,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DeptNum",
                        column: x => x.DeptNum,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpSSN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_EmpSSN",
                        column: x => x.EmpSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOnProjects",
                columns: table => new
                {
                    EmpSSN = table.Column<int>(type: "int", nullable: false),
                    projNum = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    EmployeesSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOnProjects", x => new { x.EmpSSN, x.projNum });
                    table.ForeignKey(
                        name: "FK_WorksOnProjects_Employees_EmployeesSSN",
                        column: x => x.EmployeesSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                    table.ForeignKey(
                        name: "FK_WorksOnProjects_Projects_projNum",
                        column: x => x.projNum,
                        principalTable: "Projects",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmpSSN",
                table: "Dependents",
                column: "EmpSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorSSN",
                table: "Employees",
                column: "SupervisorSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeptNum",
                table: "Projects",
                column: "DeptNum");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOnProjects_EmployeesSSN",
                table: "WorksOnProjects",
                column: "EmployeesSSN");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOnProjects_projNum",
                table: "WorksOnProjects",
                column: "projNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLocation");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "WorksOnProjects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
