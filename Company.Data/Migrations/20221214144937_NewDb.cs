using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrgNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_CompanyInfos_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    HasUnion = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateTable(
                name: "EmployeeTitles",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTitles", x => new { x.EmployeeId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_EmployeeTitles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTitles_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyInfos",
                columns: new[] { "Id", "Name", "OrgNum" },
                values: new object[,]
                {
                    { 1, "Nordic Hair Sweden", 55656667 },
                    { 2, "Nordic Hair Norway", 65757777 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "TitleName" },
                values: new object[,]
                {
                    { 1, "Teamlead" },
                    { 2, "Service Desk" },
                    { 3, "Head Of Department" },
                    { 4, "CIO" },
                    { 5, "CEO" },
                    { 6, "Manager" },
                    { 7, "Communicator" },
                    { 8, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Administration-SE" },
                    { 2, 1, "Finance-SE" },
                    { 3, 2, "Marketing-No" },
                    { 4, 2, "Purchase-No" },
                    { 5, 1, "Logistik-SE" },
                    { 6, 1, "IT-SE" },
                    { 7, 1, "Production-SE" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FirtName", "HasUnion", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "Jon", true, "Doe", 40000.0 },
                    { 2, 2, "Sara", true, "Smith", 45000.0 },
                    { 3, 2, "Alex", true, "Larssen", 45000.0 },
                    { 4, 3, "Fredrik", true, "Nilsson", 50000.0 },
                    { 5, 4, "Eva", true, "Olsson", 47000.0 },
                    { 6, 5, "Isac", true, "Freja", 38000.0 },
                    { 7, 6, "Jonas", true, "Axelsson", 48000.0 },
                    { 8, 7, "David", true, "Adams", 39000.0 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTitles",
                columns: new[] { "EmployeeId", "TitleId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 2 },
                    { 5, 1 },
                    { 6, 7 },
                    { 6, 8 },
                    { 8, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");


            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTitles_TitleId",
                table: "EmployeeTitles",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTitles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyInfos");
        }
    }
}
