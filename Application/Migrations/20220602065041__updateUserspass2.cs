using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _updateUserspass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("113b89b3-bbe6-4c8e-a877-8ef3576a022e"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("0277abb7-d655-4755-858c-628041aef3b5"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "db377755-57c4-424e-a568-995a370a8bb3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb782347-a46d-4874-aeac-ceafb3bc59d3",
                column: "ConcurrencyStamp",
                value: "8f9b7818-2a3b-4dca-9bb3-7c2884ecb0d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c",
                column: "ConcurrencyStamp",
                value: "265fd489-c0dd-4d22-91e3-b326610515c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "030afcb5-ccd4-4959-8744-490c8f798be3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7a74bd9-fda6-417a-bd24-30109ce53c28", "AQAAAAEAACcQAAAAEBGIkRk2hDDdZcuTajpkE86fr0hL7RKB4VhaqcIm8osq60snibCRR+HrFyOdG0moKA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03af6ac3-5958-4ac5-9a9e-fcd5e44c56f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c918f82a-5679-4d3b-8e48-67c39c031153", "AQAAAAEAACcQAAAAELpIGYUEvRd7Y1Ua6mY+A6zuwgRXHDuFhA/012SPtLKMyDGKnuVI63NCKvE//2zdig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2be7de8e-5c8b-4873-b0da-3f9075891053",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25ea53a7-e42d-4037-840f-2993ddbfa37c", "AQAAAAEAACcQAAAAEIiKeeOsztFKD9UX+SqyO2k+3CTzlgBuwqGSGc3GfUhT+NZLtx59nfdiPOcBVKcSUg==" });

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4abe3e76-37ed-4132-86c9-2e81db181647"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 2, 6, 48, 57, 10, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "NewsBlock",
                keyColumn: "Id",
                keyValue: new Guid("4e9efb20-7ab7-4e4f-a8eb-a0bcc432f395"),
                column: "CreateDate",
                value: new DateTime(2022, 6, 2, 6, 48, 57, 10, DateTimeKind.Utc).AddTicks(394));

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "BlockId", "Couple", "DateOfBlock" },
                values: new object[] { new Guid("113b89b3-bbe6-4c8e-a877-8ef3576a022e"), new Guid("9776fc60-1e4c-4c38-9ec5-53256ba19fec"), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("0277abb7-d655-4755-858c-628041aef3b5"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });
        }
    }
}
