using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class _updateUserspass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: new Guid("173359ed-e806-48a5-895d-07d35a31cd67"));

            migrationBuilder.DeleteData(
                table: "StudentsEstimates",
                keyColumn: "Id",
                keyValue: new Guid("f1ae7980-4055-4b35-b243-549cec6a6e2a"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "StudentsEstimates",
                columns: new[] { "Id", "Estimate", "StudentId", "SubjectId" },
                values: new object[] { new Guid("f1ae7980-4055-4b35-b243-549cec6a6e2a"), 60f, new Guid("74369f45-60d7-45a4-8291-6c6ff8b7a194"), new Guid("e4366272-a66c-4e5f-af58-976a3f441e23") });
        }
    }
}
