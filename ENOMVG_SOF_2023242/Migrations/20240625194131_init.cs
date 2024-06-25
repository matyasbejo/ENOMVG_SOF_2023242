using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENOMVG_SOF_2023242.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    GradesAVG = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    MainSubject = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Age", "ImageFileName", "Name", "Type" },
                values: new object[] { 1, 0, "", "Soproni Széchenyi István Gimnázium", 2 });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Age", "ImageFileName", "Name", "Type" },
                values: new object[] { 2, 0, "", "Berzsenyi Dániel Evangélikus (Líceum) Gimnázium és Kollégium", 2 });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Age", "ImageFileName", "Name", "Type" },
                values: new object[] { 3, 0, "", "Soproni Deák Téri Általános Iskola", 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "GradesAVG", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 1, 16, 5.0, "Bejó Mátyás", 1 },
                    { 2, 17, 3.2400000000000002, "Szojka Áron", 1 },
                    { 3, 17, 4.7599999999999998, "Hargitai Benke", 2 },
                    { 4, 13, 4.4530000000000003, "Dejó Dorka", 3 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "MainSubject", "Name", "Salary", "SchoolId" },
                values: new object[,]
                {
                    { 1, 0, "Zsoldos Gyöngyi", 270000, 3 },
                    { 2, 0, "Márti néni", 245330, 3 },
                    { 3, 2, "Lang", 400000, 1 },
                    { 4, 3, "Jakab", 431000, 1 },
                    { 5, 1, "Kovács Antal József", 220000, 2 },
                    { 6, 5, "Kiss Egér", 298000, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
