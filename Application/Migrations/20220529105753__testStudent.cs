using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _testStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("d63d1e3c-831d-442a-97b4-d8a5ed7c6c35"));

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

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"), "KC-181" });

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
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e4366272-a66c-4e5f-af58-976a3f441e23"), "Math" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GroupId", "StudentId" },
                values: new object[] { new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"), "2be7de8e-5c8b-4873-b0da-3f9075891053" });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("5a603946-c2d5-414f-95df-bf47ad678d9a"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("c97eb71e-95ff-4634-8857-a9972fcb5faa"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("5a603946-c2d5-414f-95df-bf47ad678d9a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("e4366272-a66c-4e5f-af58-976a3f441e23"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("a5f1fa56-f2cb-4d88-b57a-b8d271bce04a"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839c91ae-d73d-4c2b-aa11-7602e2e0189a",
                column: "ConcurrencyStamp",
                value: "836cceec-b25a-4902-8e14-d7540f7f6563");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "7d1e7034-53bc-4bde-9ed8-ae73cf7b704b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "e84d2afa-0d33-426b-a768-4f313d1fede4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5b1d534-930c-4d6d-9295-d7cabe2d4be2", "AQAAAAEAACcQAAAAEEPuflXl15HmZkcUmHX2I2k+coAaPrDnJFMZa7l6jUWyui2kZvBW8gvElfukC2oXxQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8248afb-4734-4d8d-acb4-20e15194ff72", "AQAAAAEAACcQAAAAEKiOIOTfZCaYrQSye9RJPiUYDPX2a7FRO6W2Ayu6br8PSfEM6zsQSpnFjd1HIeQnMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c62b2d86-9b2f-41ae-a327-85d42fd776d0", "AQAAAAEAACcQAAAAEBQNFoJlaAleoQX1y+MrGjJWvtCriwN55zC3Vah3P8yuzupsDttPxQFY5XE1fg3t0Q==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 9, 24, 37, 623, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 5, 29, 9, 24, 37, 623, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("d63d1e3c-831d-442a-97b4-d8a5ed7c6c35"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
