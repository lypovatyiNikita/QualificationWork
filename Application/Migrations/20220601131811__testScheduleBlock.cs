using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _testScheduleBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("6a7af986-1677-4939-bc69-aadd00d40cb8"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("b2f404f1-34d2-43b8-a63a-e55a4a670383"));

            migrationBuilder.DropColumn(
                name: "Group",
                table: "ScheduleBlock");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "ScheduleBlock");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "ScheduleBlock",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "ScheduleBlock",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "b613d451-aa35-441e-ad4a-c2bd723ec064");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "46b29bb2-08b0-48c2-999c-061f9c4e8ff9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "522e92a1-1fe0-42db-a277-fe3c4091f938");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80291d56-640d-43ea-912b-2bece5d0ad8c", "AQAAAAEAACcQAAAAEAS0gSugast8GSdOcW039/rpbqv2PnALN3tOOtb1ZnS6j5BaVBdxbaFO1GxWy+BmLQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8519c1d-13c1-4cfb-a7ed-7eb02e7ce3ea", "AQAAAAEAACcQAAAAEEcv3wJFXCSw4z/9wFG9G/BpwH1WtLUBHvrG5QXLO+UKtHl5rEsYAiYeO3Z2dE0bhA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45082abc-b7ec-42fd-ba4f-0c3650d02e93", "AQAAAAEAACcQAAAAEMJWzo4XKL10bP3/Sx/I1hx/umjx1IY4nacZVRS6gzNh/mSA5JuDyotvoGstTL0jVw==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 1, 13, 18, 10, 985, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 1, 13, 18, 10, 985, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("173359ed-e806-48a5-895d-07d35a31cd67"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ScheduleBlock",
                keyColumn: "Id",
                keyValue: new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
                columns: new[] { "GroupId", "TeacherId" },
                values: new object[] { new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"), new Guid("48885565-17fb-4d5b-b03c-da025f06a43b") });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("f1ae7980-4055-4b35-b243-549cec6a6e2a"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBlock_GroupId",
                table: "ScheduleBlock",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBlock_TeacherId",
                table: "ScheduleBlock",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBlock_Groups_GroupId",
                table: "ScheduleBlock",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBlock_Teachers_TeacherId",
                table: "ScheduleBlock",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBlock_Groups_GroupId",
                table: "ScheduleBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBlock_Teachers_TeacherId",
                table: "ScheduleBlock");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleBlock_GroupId",
                table: "ScheduleBlock");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleBlock_TeacherId",
                table: "ScheduleBlock");

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("173359ed-e806-48a5-895d-07d35a31cd67"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("f1ae7980-4055-4b35-b243-549cec6a6e2a"));

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ScheduleBlock");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ScheduleBlock");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "ScheduleBlock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "ScheduleBlock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "f46ef2e7-4885-4a15-937e-1a90d1917258");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "cde423f8-5727-4ba4-bda3-532c0b878c94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "b4b18bda-fd83-4110-82ea-9ecd0533ec0a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b5687af-8794-4abb-85c9-bf413b9fab90", "AQAAAAEAACcQAAAAEPcYH/AAbYKDZLN06d0Q4mKZQ5R1Wq+WJlqyn0QaCpgxdLyHLsFySB05OaXcwNGK5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "939bd5a8-bc30-40a8-8d95-81114d7cb2e0", "AQAAAAEAACcQAAAAEIbbsR4w2yU3Yj4vbPnTJFSAnOZeWKdeoZ+GSrw5f2Nl029pIjy0OTln61H8AKC0eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90d51f52-74bc-4662-92c4-19a08f76f707", "AQAAAAEAACcQAAAAEM1IB80xTORw18gkeUkjAubO9mnTuW62uh+4pzYIJQSr9CwRpBO7TpHDd2Bv9dYk6w==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 13, 47, 49, 923, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 13, 47, 49, 923, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("6a7af986-1677-4939-bc69-aadd00d40cb8"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ScheduleBlock",
                keyColumn: "Id",
                keyValue: new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"),
                columns: new[] { "Group", "Teacher" },
                values: new object[] { "KC-181", "Test teacher" });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("b2f404f1-34d2-43b8-a63a-e55a4a670383"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });
        }
    }
}
