using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _updateOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Subjects_SubjectId",
                table: "GroupSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleBlock_BlockId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEstimates_Students_StudentId",
                table: "StudentsEstimates");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEstimates_Subjects_SubjectId",
                table: "StudentsEstimates");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("808450df-aa6b-4b1a-939a-6b4ec26badb4"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("c6b042c5-b411-438e-8f6f-f55f43a1dc0b"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "6fa8ac00-85dd-4a57-9ec5-5b6436b2f410");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "c1ab5081-154a-4c2e-9720-e30d0814acca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "90abc330-b5b3-47b6-bfd6-62741b102ce6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6658190-f5ba-4b92-83fd-776d2f429c31", "AQAAAAEAACcQAAAAEDMRuZtq/V+FcgVoTNKs8aK5gv3ca0A19hBvY7kr+3sFBTQ4BeBeZvKWZcNqLgd5Gw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f775f9cd-ba5b-469b-b4c1-e68d97cb8373", "AQAAAAEAACcQAAAAEESRx2GdR0ifSAkZzbfV+qNyw1G0kd4ZOdH4GKMZkZoh2U81zZXyl6p6aGp4HAfPVA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85ee7719-7973-4b15-af84-18566291c316", "AQAAAAEAACcQAAAAEEcFVcVs5qexMfC/1DjUFNabpowMjGdecY4iH0vJRYK1uPvYwMTtd25lVx4AaP0aLw==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 5, 12, 35, 0, 423, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 5, 12, 35, 0, 423, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("99207f36-796d-4b1a-b800-3b6721fda262"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("2fb0dec2-fedc-4a29-a2f1-9aa94cff379b"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Subjects_SubjectId",
                table: "GroupSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleBlock_BlockId",
                table: "Schedule",
                column: "BlockId",
                principalTable: "ScheduleBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEstimates_Students_StudentId",
                table: "StudentsEstimates",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEstimates_Subjects_SubjectId",
                table: "StudentsEstimates",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Subjects_SubjectId",
                table: "GroupSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleBlock_BlockId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEstimates_Students_StudentId",
                table: "StudentsEstimates");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEstimates_Subjects_SubjectId",
                table: "StudentsEstimates");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_TeacherId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("99207f36-796d-4b1a-b800-3b6721fda262"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("2fb0dec2-fedc-4a29-a2f1-9aa94cff379b"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "e409e4b7-c6aa-44f6-99db-0eaf81e55c59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "d81a9e9f-1bb0-4ee1-90e0-8683d8972a14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "6676af8e-401b-4259-bd62-78f016674df7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65e06041-9acb-45d7-8e41-56f5649941fc", "AQAAAAEAACcQAAAAEK2kn31uQYzBtvLggMizaFEJUlFlXdLe9gpULeLQYfyqNkLEUkhdGosR96ZVRHVN8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a99fd69-8101-4c10-8b21-6a2a9e4edb4e", "AQAAAAEAACcQAAAAEOPN6UaT8FQISipshOpftZ8qBQptI64PTqCdw7Q88iA8pzWHKirykZxt9b9dNOcLdw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1529e8ff-fd33-4f91-a98b-9b310c298aa9", "AQAAAAEAACcQAAAAEHdTq0YuANi4ehIjOsqB71Qn1hRISSJABNSr1Db3aI/GGyxmter7tftt0fowMP9i4w==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 2, 6, 50, 40, 664, DateTimeKind.Utc).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 2, 6, 50, 40, 664, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("808450df-aa6b-4b1a-939a-6b4ec26badb4"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("c6b042c5-b411-438e-8f6f-f55f43a1dc0b"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Subjects_SubjectId",
                table: "GroupSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleBlock_BlockId",
                table: "Schedule",
                column: "BlockId",
                principalTable: "ScheduleBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEstimates_Students_StudentId",
                table: "StudentsEstimates",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEstimates_Subjects_SubjectId",
                table: "StudentsEstimates",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_TeacherId",
                table: "Teachers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
