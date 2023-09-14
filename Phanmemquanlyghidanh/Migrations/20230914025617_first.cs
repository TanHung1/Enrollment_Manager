using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckOutRooms",
                columns: table => new
                {
                    CheckOut_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOut_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutRooms", x => x.CheckOut_Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Schedule_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Schedule_Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusRooms",
                columns: table => new
                {
                    StatusRoom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusRoom_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRooms", x => x.StatusRoom_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategories",
                columns: table => new
                {
                    SubjectCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCategory_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategories", x => x.SubjectCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name_Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOut_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_Students_CheckOutRooms_CheckOut_Id",
                        column: x => x.CheckOut_Id,
                        principalTable: "CheckOutRooms",
                        principalColumn: "CheckOut_Id");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subject_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SubjectCategory_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subject_Id);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectCategories_SubjectCategory_Id",
                        column: x => x.SubjectCategory_Id,
                        principalTable: "SubjectCategories",
                        principalColumn: "SubjectCategory_Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCard = table.Column<int>(type: "int", nullable: false),
                    Teacher_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Teacher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CooperationDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subjects",
                        principalColumn: "Subject_Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    ClassRoom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoom_Name = table.Column<int>(type: "int", nullable: false),
                    ClassRoom_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberofStudent = table.Column<int>(type: "int", nullable: false),
                    SchoolRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOut_Id = table.Column<int>(type: "int", nullable: true),
                    Schedule_Id = table.Column<int>(type: "int", nullable: true),
                    StatusRoom_Id = table.Column<int>(type: "int", nullable: true),
                    Student_Id = table.Column<int>(type: "int", nullable: true),
                    Subject_Id = table.Column<int>(type: "int", nullable: true),
                    Teacher_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassRoom_Id);
                    table.ForeignKey(
                        name: "FK_ClassRooms_CheckOutRooms_CheckOut_Id",
                        column: x => x.CheckOut_Id,
                        principalTable: "CheckOutRooms",
                        principalColumn: "CheckOut_Id");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Schedules_Schedule_Id",
                        column: x => x.Schedule_Id,
                        principalTable: "Schedules",
                        principalColumn: "Schedule_Id");
                    table.ForeignKey(
                        name: "FK_ClassRooms_StatusRooms_StatusRoom_Id",
                        column: x => x.StatusRoom_Id,
                        principalTable: "StatusRooms",
                        principalColumn: "StatusRoom_Id");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Student_Id");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subjects",
                        principalColumn: "Subject_Id");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Teachers_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "Teachers",
                        principalColumn: "Teacher_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CheckOut_Id",
                table: "ClassRooms",
                column: "CheckOut_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Schedule_Id",
                table: "ClassRooms",
                column: "Schedule_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_StatusRoom_Id",
                table: "ClassRooms",
                column: "StatusRoom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Student_Id",
                table: "ClassRooms",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Subject_Id",
                table: "ClassRooms",
                column: "Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Teacher_Id",
                table: "ClassRooms",
                column: "Teacher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CheckOut_Id",
                table: "Students",
                column: "CheckOut_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCategory_Id",
                table: "Subjects",
                column: "SubjectCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subject_Id",
                table: "Teachers",
                column: "Subject_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "StatusRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "CheckOutRooms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "SubjectCategories");
        }
    }
}
