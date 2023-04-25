using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GloboTicket.TicketManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequiredChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1468), null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1402), null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1447), null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1494), null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1426), null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1350), null, null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 18, 11, 22, 28, 277, DateTimeKind.Local).AddTicks(1630));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2024, 2, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2024, 1, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 8, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 12, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 8, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 10, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2023, 4, 12, 16, 21, 55, 344, DateTimeKind.Local).AddTicks(5351));
        }
    }
}
