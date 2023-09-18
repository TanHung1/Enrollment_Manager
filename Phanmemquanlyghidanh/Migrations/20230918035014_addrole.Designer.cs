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
    [Migration("20230918035014_addrole")]
    partial class addrole
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CheckOut_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CooperationDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityCard")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Parent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Subject_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckOut_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Subject_Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.CheckOut", b =>
                {
                    b.Property<int>("CheckOut_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckOut_Id"));

                    b.Property<string>("CheckOut_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CheckOut_Id");

                    b.ToTable("CheckOutRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoom_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoom_Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("CheckOut_Id")
                        .HasColumnType("int");

                    b.Property<string>("ClassRoom_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassRoom_Name")
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberofStudent")
                        .HasColumnType("int");

                    b.Property<int?>("Schedule_Id")
                        .HasColumnType("int");

                    b.Property<string>("SchoolDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolRoom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusRoom_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Subject_Id")
                        .HasColumnType("int");

                    b.Property<string>("TimeClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassRoom_Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CheckOut_Id");

                    b.HasIndex("Schedule_Id");

                    b.HasIndex("StatusRoom_Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<decimal>("AverageColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FirstColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FourthColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ThirdColumnPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TypeMarkTypeID")
                        .HasColumnType("int");

                    b.HasKey("MarkId");

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
                    b.Property<int>("Schedule_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Schedule_Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Schedule_Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusRoom", b =>
                {
                    b.Property<int>("StatusRoom_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusRoom_Id"));

                    b.Property<string>("StatusRoom_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusRoom_Id");

                    b.ToTable("StatusRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.Property<int>("Subject_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarkId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectCategory_Id")
                        .HasColumnType("int");

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_Id");

                    b.HasIndex("MarkId");

                    b.HasIndex("SubjectCategory_Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.SubjectCategory", b =>
                {
                    b.Property<int>("SubjectCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectCategory_Id"));

                    b.Property<string>("SubjectCategory_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectCategory_Id");

                    b.ToTable("SubjectCategories");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.TypeMark", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeID"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("TypeMarks");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Account", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.CheckOut", null)
                        .WithMany("Accounts")
                        .HasForeignKey("CheckOut_Id");

                    b.HasOne("Phanmemquanlyghidanh.Models.Role", null)
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");

                    b.HasOne("Phanmemquanlyghidanh.Models.Subject", null)
                        .WithMany("Accounts")
                        .HasForeignKey("Subject_Id");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.ClassRoom", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Account", null)
                        .WithMany("ClassRooms")
                        .HasForeignKey("AccountId");

                    b.HasOne("Phanmemquanlyghidanh.Models.CheckOut", null)
                        .WithMany("ClassRooms")
                        .HasForeignKey("CheckOut_Id");

                    b.HasOne("Phanmemquanlyghidanh.Models.Schedule", null)
                        .WithMany("ClassRooms")
                        .HasForeignKey("Schedule_Id");

                    b.HasOne("Phanmemquanlyghidanh.Models.StatusRoom", null)
                        .WithMany("Classrooms")
                        .HasForeignKey("StatusRoom_Id");

                    b.HasOne("Phanmemquanlyghidanh.Models.Subject", null)
                        .WithMany("Classrooms")
                        .HasForeignKey("Subject_Id");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Mark", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.TypeMark", null)
                        .WithMany("Marks")
                        .HasForeignKey("TypeMarkTypeID");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.HasOne("Phanmemquanlyghidanh.Models.Mark", null)
                        .WithMany("Subjects")
                        .HasForeignKey("MarkId");

                    b.HasOne("Phanmemquanlyghidanh.Models.SubjectCategory", null)
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectCategory_Id");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Account", b =>
                {
                    b.Navigation("ClassRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.CheckOut", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("ClassRooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Mark", b =>
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

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.StatusRoom", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("Phanmemquanlyghidanh.Models.Subject", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Classrooms");
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
