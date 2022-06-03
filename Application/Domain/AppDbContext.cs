using Application.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
	public class AppDbContext : IdentityDbContext<UniversityUser>
	{
		public DbSet<NewsBlock> NewsBlock { get; set; }
		public DbSet<Schedule> Schedule { get; set; }
		public DbSet<ScheduleBlock> ScheduleBlock { get; set; }
		public DbSet<Message> Message { get; set; }
		public DbSet<UniversityUser> UniversityUser { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<GroupSubject> GroupSubjects { get; set; }
		public DbSet<TeacherSubject> TeacherSubjects { get; set; }
		public DbSet<StudentsEstimates> StudentsEstimates { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Schedule>()
				.HasOne(x => x.Block)
				.WithMany(x => x.Schedules)
				.HasForeignKey(x => x.BlockId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Student>()
				.HasOne(x => x.StudentUser)
				.WithMany(x => x.Students)
				.HasForeignKey(x => x.StudentId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Student>()
				.HasOne(x => x.Group)
				.WithMany(x => x.Students)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Teacher>()
				.HasOne(x => x.TeacherUser)
				.WithMany(x => x.Teachers)
				.HasForeignKey(x => x.TeacherId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<GroupSubject>()
				.HasOne(x => x.Group)
				.WithMany(x => x.GroupSubjects)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<GroupSubject>()
				.HasOne(x => x.Subject)
				.WithMany(x => x.GroupsWithSubject)
				.HasForeignKey(x => x.SubjectId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<TeacherSubject>()
				.HasOne(x => x.Teacher)
				.WithMany(x => x.TeacherSubjects)
				.HasForeignKey(x => x.TeacherId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<TeacherSubject>()
				.HasOne(x => x.Subject)
				.WithMany(x => x.TeachersInSubject)
				.HasForeignKey(x => x.SubjectId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<StudentsEstimates>()
				.HasOne(x => x.Student)
				.WithMany(x => x.StudentsEstimates)
				.HasForeignKey(x => x.StudentId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<StudentsEstimates>()
				.HasOne(x => x.Subject)
				.WithMany(x => x.SubjectStudentsEstimates)
				.HasForeignKey(x => x.SubjectId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<ScheduleBlock>()
				.HasOne(x => x.Teacher)
				.WithMany(x => x.ScheduleBlocks)
				.HasForeignKey(x => x.TeacherId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<ScheduleBlock>()
				.HasOne(x => x.Group)
				.WithMany(x => x.ScheduleBlocks)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "eb782347-a46d-4874-aeac-ceafb3bc59d3",
				Name = "methodist",
				NormalizedName = "METHODIST"
			});

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
				Name = "teacher",
				NormalizedName = "TEACHER"
			});

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
				Name = "student",
				NormalizedName = "STUDENT"
			});

			builder.Entity<UniversityUser>().HasData(new UniversityUser
			{
				Id = "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
				UserName = "Methodist",
				NormalizedUserName = "METHODIST",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, "glavniymethodist123"),
				SecurityStamp = string.Empty,
				Name = "TestMethodistName",
				Surname = "TestMethodistSurname"
			});

			builder.Entity<UniversityUser>().HasData(new UniversityUser
			{
				Id = "030afcb5-ccd4-4959-8744-490c8f798be3",
				UserName = "TestTeacher",
				NormalizedUserName = "TESTTEACHER",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, "umniyteacher123"),
				SecurityStamp = string.Empty,
				Name = "TestTeacherName",
				Surname = "TestTeacherSurname"
			});

			builder.Entity<UniversityUser>().HasData(new UniversityUser
			{
				Id = "2be7de8e-5c8b-4873-b0da-3f9075891053",
				UserName = "TestStudent",
				NormalizedUserName = "TESTSTUDENT",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, "umniystudent123"),
				SecurityStamp = string.Empty,
				Name = "TestStudentName",
				Surname = "TestStudentSurname"
			});

			builder.Entity<Group>().HasData(new Group
			{
				Id = new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"),
				Name = "KC-181",
			});

			builder.Entity<Student>().HasData(new Student
			{
				Id = new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"),
				StudentId = "2be7de8e-5c8b-4873-b0da-3f9075891053",
				GroupId= new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a")
			});

			builder.Entity<Subject>().HasData(new Subject
			{
				Id = new Guid("e4366272-a66c-4e5f-af58-976a3f441e23"),
				Name = "Math",
			});

			builder.Entity<StudentsEstimates>().HasData(new StudentsEstimates
			{
				Id = Guid.NewGuid(),
				StudentId = new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"),
				SubjectId = new Guid("e4366272-a66c-4e5f-af58-976a3f441e23"),
				Estimate = 60
			});

			builder.Entity<Teacher>().HasData(new Teacher
			{
				Id = new Guid("48885565-17fb-4d5b-b03c-da025f06a43b"),
				TeacherId ="030afcb5-ccd4-4959-8744-490c8f798be3"
			});

			builder.Entity<TeacherSubject>().HasData(new TeacherSubject
			{
				Id = new Guid("3f2f8ac5-6851-4e88-9a0f-459f6c388f44"),
				TeacherId = new Guid("48885565-17fb-4d5b-b03c-da025f06a43b"),
				SubjectId = new Guid("e4366272-a66c-4e5f-af58-976a3f441e23")
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "eb782347-a46d-4874-aeac-ceafb3bc59d3",
				UserId = "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8"
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
				UserId = "030afcb5-ccd4-4959-8744-490c8f798be3"
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
				UserId = "2be7de8e-5c8b-4873-b0da-3f9075891053"
			});

			builder.Entity<NewsBlock>().HasData(new NewsBlock
			{
				Id = new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
				Title = "Test",
				Subtitle = "Test",
				Text = "TestTestTest"
			});

			builder.Entity<NewsBlock>().HasData(new NewsBlock
			{
				Id = new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
				Title = "Test2",
				Subtitle = "Test2",
				Text = "TestTestTest2"
			});

			builder.Entity<ScheduleBlock>().HasData(new ScheduleBlock
			{
				Id = new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
				Title = "Test",
				Audience = "Test room",
				GroupId = new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"),
				TeacherId = new Guid("48885565-17fb-4d5b-b03c-da025f06a43b")
			});

			builder.Entity<Schedule>().HasData(new Schedule
			{
				Id = Guid.NewGuid(),
				BlockId = new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
				Couple = 1,
				DateOfBlock = new DateTime(2021, 1, 1)
			});

		}
	}
}
