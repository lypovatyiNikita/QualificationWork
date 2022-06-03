using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _testTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("c97eb71e-95ff-4634-8857-a9972fcb5faa"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("5a603946-c2d5-414f-95df-bf47ad678d9a"));

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

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("b2f404f1-34d2-43b8-a63a-e55a4a670383"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "TeacherId" },
                values: new object[] { new Guid("48885565-17fb-4d5b-b03c-da025f06a43b"), "030afcb5-ccd4-4959-8744-490c8f798be3" });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "Id", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("3f2f8ac5-6851-4e88-9a0f-459f6c388f44"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23"), new Guid("48885565-17fb-4d5b-b03c-da025f06a43b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("6a7af986-1677-4939-bc69-aadd00d40cb8"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("b2f404f1-34d2-43b8-a63a-e55a4a670383"));

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumn: "Id",
                keyValue: new Guid("3f2f8ac5-6851-4e88-9a0f-459f6c388f44"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("48885565-17fb-4d5b-b03c-da025f06a43b"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "d7be5868-0f10-4858-a8d0-28cfcbb77f5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "f102e7d6-4a91-4d9d-b0d0-c7075d72c4a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "0b73c8c9-b22e-41a9-838c-0de71f083089");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5dbc4032-91bd-4a0b-a370-a639ab871380", "AQAAAAEAACcQAAAAEBaiVSIfdI/j86NOjsLo5GF1buwnAO/CN8gzunhfZ4jDNzeiE6L89mLBxgh7utC36g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8babadc6-ab28-491a-a127-90d67836ac13", "AQAAAAEAACcQAAAAEGKQX9zbwQER7jdJ1pF7z39ZY6HFoggVhe/mNTsiOjZgnuoVo69kDo026miHfFqrfA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76ad6b10-75f3-4051-856f-a8fe7bf36339", "AQAAAAEAACcQAAAAENoRtvcZz2d2WsIuohgMO+59Ki5aPB8GPJ/RLz+6kfp8dWUK7/C8+Ueoej/1y8JOiA==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 10, 57, 53, 542, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 10, 57, 53, 542, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("c97eb71e-95ff-4634-8857-a9972fcb5faa"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("5a603946-c2d5-414f-95df-bf47ad678d9a"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });
        }
    }
}
