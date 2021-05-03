using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApp.Service.WebAPI.Migrations
{
    public partial class addRemind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemind",
                table: "MyTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 5, 3, 1, 41, 54, 278, DateTimeKind.Local).AddTicks(9361), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(6717), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7331), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7385), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7602), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7842), new DateTime(2020, 6, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7845), new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7915), new DateTime(2019, 7, 18, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7848) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemind",
                table: "MyTasks");

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 5, 1, 19, 12, 10, 136, DateTimeKind.Local).AddTicks(6483), new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(1013), new DateTime(2021, 5, 1, 19, 12, 10, 138, DateTimeKind.Local).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2273), new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2403), new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2480), new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2654), new DateTime(2020, 6, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2636) });

            migrationBuilder.UpdateData(
                table: "MyTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "TaskDate", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2658), new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2773), new DateTime(2019, 7, 16, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2665) });
        }
    }
}
