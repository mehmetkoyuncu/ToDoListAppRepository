using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApp.Service.WebAPI.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MyTasks",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "IsDone", "TaskContent", "TaskDate", "TaskTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 1, 19, 12, 10, 136, DateTimeKind.Local).AddTicks(6483), false, true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(1013), "Lorem Ipsum", new DateTime(2021, 5, 1, 19, 12, 10, 138, DateTimeKind.Local).AddTicks(5258) },
                    { 2, new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2273), false, false, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2403), "Contrary to popular", new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2306) },
                    { 3, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contrary to popula", new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2480), true, true, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.", new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2654), "There are many variations", new DateTime(2020, 6, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2636) },
                    { 5, new DateTime(2018, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2658), false, false, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.", new DateTime(2021, 5, 1, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2773), "There are many variations", new DateTime(2019, 7, 16, 19, 12, 10, 139, DateTimeKind.Local).AddTicks(2665) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTasks");
        }
    }
}
