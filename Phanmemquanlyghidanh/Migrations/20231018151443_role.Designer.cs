﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phanmemquanlyghidanh.Models;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    [DbContext(typeof(EnrollmentDBContext))]
    [Migration("20231018151443_role")]
    partial class role
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CooperationDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityCard")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Parent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.CheckOut", b =>
                {
                    b.Property<int>("CheckOutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckOutId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CheckOut_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassRoom_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ClassRoom_Id1")
                        .HasColumnType("int");

                    b.Property<string>("FeeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCheckOutId")
                        .HasColumnType("int");

                    b.HasKey("CheckOutId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClassRoom_Id1");

                    b.HasIndex("StatusCheckOutId");

                    b.ToTable("CheckOuts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoom_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoom_Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassRoom_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassRoom_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassRoom_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberofStudent")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("SchoolDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolRoom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("TimeClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassRoom_Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("StatusRoomId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.HolidaySchedule", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HolidayId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameHoliday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.HasKey("HolidayId");

                    b.ToTable("HolidaySchedules");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("AverageColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalExamPoint1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalExamPoint2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FirstColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FourthColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("ThirdColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int?>("TypeMarkTypeID")
                        .HasColumnType("int");

                    b.HasKey("MarkId");

                    b.HasIndex("AccountId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TypeMarkTypeID");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusCheckOut", b =>
                {
                    b.Property<int>("StatusCheckOutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusCheckOutId"));

                    b.Property<string>("StatusCheckOutName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusCheckOutId");

                    b.ToTable("StatusCheckouts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusRoom", b =>
                {
                    b.Property<int>("StatusRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusRoomId"));

                    b.Property<string>("StatusRoom_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusRoomId");

                    b.ToTable("StatusRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SubjectCategoryId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.SubjectCategory", b =>
                {
                    b.Property<int>("SubjectCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectCategoryId"));

                    b.Property<string>("SubjectCategory_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectCategoryId");

                    b.ToTable("SubjectCategories");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.TypeMark", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeID"));

                    b.Property<string>("Coefficient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("TypeMarks");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Account", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Role", null)
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.CheckOut", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Account", null)
                        .WithMany("checkouts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.ClassRoom", null)
                        .WithMany("checkOuts")
                        .HasForeignKey("ClassRoom_Id1");

                    b.HasOne("Phanmemquanlyghidanh.Models.StatusCheckOut", null)
                        .WithMany("CheckOuts")
                        .HasForeignKey("StatusCheckOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.ClassRoom", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Account", null)
                        .WithMany("ClassRooms")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.Schedule", null)
                        .WithMany("ClassRooms")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.StatusRoom", null)
                        .WithMany("Classrooms")
                        .HasForeignKey("StatusRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.Subject", null)
                        .WithMany("Classrooms")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Mark", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Account", null)
                        .WithMany("marks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.Subject", null)
                        .WithMany("marks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.TypeMark", null)
                        .WithMany("Marks")
                        .HasForeignKey("TypeMarkTypeID");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Course", null)
                        .WithMany("Subjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phanmemquanlyghidanh.Models.SubjectCategory", null)
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Account", b =>
                {
                    b.Navigation("ClassRooms");

                    b.Navigation("checkouts");

                    b.Navigation("marks");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.ClassRoom", b =>
                {
                    b.Navigation("checkOuts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Course", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Schedule", b =>
                {
                    b.Navigation("ClassRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusCheckOut", b =>
                {
                    b.Navigation("CheckOuts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusRoom", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.Navigation("Classrooms");

                    b.Navigation("marks");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.SubjectCategory", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.TypeMark", b =>
                {
                    b.Navigation("Marks");
                });
#pragma warning restore 612, 618
        }
    }
}
