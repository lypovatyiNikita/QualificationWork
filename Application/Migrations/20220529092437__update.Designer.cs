﻿// <auto-generated />
using System;
using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220529092437__update")]
    partial class _update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Application.Domain.Entities.GroupSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("GroupSubjects");
                });

            modelBuilder.Entity("Application.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Application.Domain.Entities.NewsBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsBlock");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                            CreateDate = new DateTime(2022, 5, 29, 9, 24, 37, 623, DateTimeKind.Utc).AddTicks(5213),
                            Subtitle = "Test",
                            Text = "TestTestTest",
                            Title = "Test"
                        },
                        new
                        {
                            Id = new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                            CreateDate = new DateTime(2022, 5, 29, 9, 24, 37, 623, DateTimeKind.Utc).AddTicks(6161),
                            Subtitle = "Test2",
                            Text = "TestTestTest2",
                            Title = "Test2"
                        });
                });

            modelBuilder.Entity("Application.Domain.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Couple")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBlock")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Schedule");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d63d1e3c-831d-442a-97b4-d8a5ed7c6c35"),
                            BlockId = new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
                            Couple = 1,
                            DateOfBlock = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Application.Domain.Entities.ScheduleBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Audience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScheduleBlock");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
                            Audience = "Test room",
                            Group = "KC-181",
                            Teacher = "Test teacher",
                            Title = "Test"
                        });
                });

            modelBuilder.Entity("Application.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Application.Domain.Entities.StudentsEstimates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Estimate")
                        .HasColumnType("real");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentsEstimates");
                });

            modelBuilder.Entity("Application.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Application.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Application.Domain.Entities.TeacherSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                            ConcurrencyStamp = "7d1e7034-53bc-4bde-9ed8-ae73cf7b704b",
                            Name = "methodist",
                            NormalizedName = "METHODIST"
                        },
                        new
                        {
                            Id = "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                            ConcurrencyStamp = "e84d2afa-0d33-426b-a768-4f313d1fede4",
                            Name = "teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                            ConcurrencyStamp = "836cceec-b25a-4902-8e14-d7540f7f6563",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                            RoleId = "eb782347-a46d-4874-aeac-ceafb3bc59d3"
                        },
                        new
                        {
                            UserId = "030afcb5-ccd4-4959-8744-490c8f798be3",
                            RoleId = "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c"
                        },
                        new
                        {
                            UserId = "2be7de8e-5c8b-4873-b0da-3f9075891053",
                            RoleId = "839c91ae-d73d-4c2b-aa11-7602e2e0189a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.UniversityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d8248afb-4734-4d8d-acb4-20e15194ff72",
                            Email = "my@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "TestMethodistName",
                            NormalizedEmail = "MY@EMAIL.COM",
                            NormalizedUserName = "METHODIST",
                            PasswordHash = "AQAAAAEAACcQAAAAEKiOIOTfZCaYrQSye9RJPiUYDPX2a7FRO6W2Ayu6br8PSfEM6zsQSpnFjd1HIeQnMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Surname = "TestMethodistSurname",
                            TwoFactorEnabled = false,
                            UserName = "Methodist"
                        },
                        new
                        {
                            Id = "030afcb5-ccd4-4959-8744-490c8f798be3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b5b1d534-930c-4d6d-9295-d7cabe2d4be2",
                            Email = "my@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "TestTeacherName",
                            NormalizedEmail = "MY@EMAIL.COM",
                            NormalizedUserName = "TESTTEACHER",
                            PasswordHash = "AQAAAAEAACcQAAAAEEPuflXl15HmZkcUmHX2I2k+coAaPrDnJFMZa7l6jUWyui2kZvBW8gvElfukC2oXxQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Surname = "TestTeacherSurname",
                            TwoFactorEnabled = false,
                            UserName = "TestTeacher"
                        },
                        new
                        {
                            Id = "2be7de8e-5c8b-4873-b0da-3f9075891053",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c62b2d86-9b2f-41ae-a327-85d42fd776d0",
                            Email = "my@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "TestStudentName",
                            NormalizedEmail = "MY@EMAIL.COM",
                            NormalizedUserName = "TESTSTUDENT",
                            PasswordHash = "AQAAAAEAACcQAAAAEBQNFoJlaAleoQX1y+MrGjJWvtCriwN55zC3Vah3P8yuzupsDttPxQFY5XE1fg3t0Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Surname = "TestStudentSurname",
                            TwoFactorEnabled = false,
                            UserName = "TestStudent"
                        });
                });

            modelBuilder.Entity("Application.Domain.Entities.GroupSubject", b =>
                {
                    b.HasOne("Application.Domain.Entities.Group", "Group")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.Domain.Entities.Subject", "Subject")
                        .WithMany("GroupsWithSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("Application.Domain.Entities.ScheduleBlock", "Block")
                        .WithMany("Schedules")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.Domain.Entities.Student", b =>
                {
                    b.HasOne("Application.Domain.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", "StudentUser")
                        .WithMany("Students")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.Domain.Entities.StudentsEstimates", b =>
                {
                    b.HasOne("Application.Domain.Entities.Student", "Student")
                        .WithMany("StudentsEstimates")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.Domain.Entities.Subject", "Subject")
                        .WithMany("SubjectStudentsEstimates")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", "TeacherUser")
                        .WithMany("Teachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Application.Domain.Entities.TeacherSubject", b =>
                {
                    b.HasOne("Application.Domain.Entities.Subject", "Subject")
                        .WithMany("TeachersInSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.Domain.Entities.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.UniversityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
