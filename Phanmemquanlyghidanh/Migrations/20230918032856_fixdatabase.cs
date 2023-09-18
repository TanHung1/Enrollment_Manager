using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class fixdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Students_Student_Id",
                table: "ClassRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Teachers_Teacher_Id",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_Student_Id",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "Student_Id",
                table: "ClassRooms");

            migrationBuilder.RenameColumn(
                name: "Teacher_Id",
                table: "ClassRooms",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRooms_Teacher_Id",
                table: "ClassRooms",
                newName: "IX_ClassRooms_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "MarkId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCard = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name_Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CooperationDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOut_Id = table.Column<int>(type: "int", nullable: true),
                    Subject_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_CheckOutRooms_CheckOut_Id",
                        column: x => x.CheckOut_Id,
                        principalTable: "CheckOutRooms",
                        principalColumn: "CheckOut_Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subjects",
                        principalColumn: "Subject_Id");
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstColumnPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondColumnPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdColumnPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthColumnPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageColumnPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_MarkId",
                table: "Subjects",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CheckOut_Id",
                table: "Accounts",
                column: "CheckOut_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Subject_Id",
                table: "Accounts",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Accounts_AccountId",
                table: "ClassRooms",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Marks_MarkId",
                table: "Subjects",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "MarkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Accounts_AccountId",
                table: "ClassRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Marks_MarkId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_MarkId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ClassRooms",
                newName: "Teacher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRooms_AccountId",
                table: "ClassRooms",
                newName: "IX_ClassRooms_Teacher_Id");

            migrationBuilder.AddColumn<int>(
                name: "Student_Id",
                table: "ClassRooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOut_Id = table.Column<int>(type: "int", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name_Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Teachers",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CooperationDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityCard = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_Id = table.Column<int>(type: "int", nullable: true),
                    Teacher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_Student_Id",
                table: "ClassRooms",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CheckOut_Id",
                table: "Students",
                column: "CheckOut_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subject_Id",
                table: "Teachers",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Students_Student_Id",
                table: "ClassRooms",
                column: "Student_Id",
                principalTable: "Students",
                principalColumn: "Student_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Teachers_Teacher_Id",
                table: "ClassRooms",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Teacher_Id");
        }
    }
}
