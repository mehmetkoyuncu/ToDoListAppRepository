using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ToDoListApp.Service.WebAPI.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskTitle = table.Column<string>(type: "text", nullable: true),
                    TaskContent = table.Column<string>(type: "text", nullable: true),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    IsRemind = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "IsDone", "IsRemind", "TaskContent", "TaskDate", "TaskTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 5, 1, 5, 43, 656, DateTimeKind.Local).AddTicks(4206), false, true, false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(612), "Lorem Ipsum", new DateTime(2021, 5, 5, 1, 5, 43, 658, DateTimeKind.Local).AddTicks(6023) },
                    { 2, new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(1678), false, false, false, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(1796), "Contrary to popular", new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(1707) },
                    { 3, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contrary to popula", new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(1881), true, true, false, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.", new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(2043), "There are many variations", new DateTime(2020, 6, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(2024) },
                    { 5, new DateTime(2018, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(2049), false, false, false, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.", new DateTime(2021, 5, 5, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(2210), "There are many variations", new DateTime(2019, 7, 20, 1, 5, 43, 659, DateTimeKind.Local).AddTicks(2055) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "public");
        }
    }
}
