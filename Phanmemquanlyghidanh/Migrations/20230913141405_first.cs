using System;
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
                    CheckOut_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOut_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutRooms", x => x.CheckOut_ID);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Schedule_ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusRooms",
                columns: table => new
                {
                    StatusRoom_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusRoom_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRooms", x => x.StatusRoom_ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategories",
                columns: table => new
                {
                    SubjectCategory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCategory_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategories", x => x.SubjectCategory_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
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
                    CheckOut_ID = table.Column<int>(type: "int", nullable: false),
                    CheckOut_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK_Students_CheckOutRooms_CheckOut_ID1",
                        column: x => x.CheckOut_ID1,
                        principalTable: "CheckOutRooms",
                        principalColumn: "CheckOut_ID");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCategory_ID = table.Column<int>(type: "int", nullable: false),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SubjectCategory_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subject_ID);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectCategories_SubjectCategory_ID1",
                        column: x => x.SubjectCategory_ID1,
                        principalTable: "SubjectCategories",
                        principalColumn: "SubjectCategory_ID");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCard = table.Column<int>(type: "int", nullable: false),
                    Teacher_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Teacher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_Subject_ID1",
                        column: x => x.Subject_ID1,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    ClassRoom_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoom_Name = table.Column<int>(type: "int", nullable: false),
                    Schedule_ID = table.Column<int>(type: "int", nullable: false),
                    ClassRoom_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    SchoolDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberofStudent = table.Column<int>(type: "int", nullable: false),
                    SchoolRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusRoom_ID = table.Column<int>(type: "int", nullable: false),
                    Teacher_ID = table.Column<int>(type: "int", nullable: false),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    CheckOut_ID = table.Column<int>(type: "int", nullable: false),
                    CheckOut_ID1 = table.Column<int>(type: "int", nullable: true),
                    Schedule_ID1 = table.Column<int>(type: "int", nullable: true),
                    StatusRoom_ID1 = table.Column<int>(type: "int", nullable: true),
                    Student_ID1 = table.Column<int>(type: "int", nullable: true),
                    Subject_ID1 = table.Column<int>(type: "int", nullable: true),
                    Teacher_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassRoom_ID);
                    table.ForeignKey(
                        name: "FK_ClassRooms_CheckOutRooms_CheckOut_ID1",
                        column: x => x.CheckOut_ID1,
                        principalTable: "CheckOutRooms",
                        principalColumn: "CheckOut_ID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Schedules_Schedule_ID1",
                        column: x => x.Schedule_ID1,
                        principalTable: "Schedules",
                        principalColumn: "Schedule_ID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_StatusRooms_StatusRoom_ID1",
                        column: x => x.StatusRoom_ID1,
                        principalTable: "StatusRooms",
                        principalColumn: "StatusRoom_ID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Subjects_Subject_ID1",
                        column: x => x.Subject_ID1,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_Teachers_Teacher_ID1",
                        column: x => x.Teacher_ID1,
                        principalTable: "Teachers",
                        principalColumn: "Teacher_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CheckOut_ID1",
                table: "ClassRooms",
                column: "CheckOut_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Schedule_ID1",
                table: "ClassRooms",
                column: "Schedule_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_StatusRoom_ID1",
                table: "ClassRooms",
                column: "StatusRoom_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Student_ID1",
                table: "ClassRooms",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Subject_ID1",
                table: "ClassRooms",
                column: "Subject_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Teacher_ID1",
                table: "ClassRooms",
                column: "Teacher_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CheckOut_ID1",
                table: "Students",
                column: "CheckOut_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCategory_ID1",
                table: "Subjects",
                column: "SubjectCategory_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subject_ID1",
                table: "Teachers",
                column: "Subject_ID1");
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
