﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Infrastructure.Migrations
{
    public partial class DBSchemaV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    levelname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personid = table.Column<int>(type: "int", nullable: false),
                    profcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professors", x => x.id);
                    table.ForeignKey(
                        name: "FK_professors_persons_personid",
                        column: x => x.personid,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personid = table.Column<int>(type: "int", nullable: false),
                    levelid = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_levels_levelid",
                        column: x => x.levelid,
                        principalTable: "levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_persons_personid",
                        column: x => x.personid,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    personid = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_persons_personid",
                        column: x => x.personid,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    professorid = table.Column<int>(type: "int", nullable: false),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_professors_professorid",
                        column: x => x.professorid,
                        principalTable: "professors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_courses_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3737), "Seed Data", "Level 1", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3781), "Seed Data" },
                    { 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3786), "Seed Data", "Level 2", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3787), "Seed Data" },
                    { 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3789), "Seed Data", "Level 3", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3791), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3995), "Seed Data", "Marouane", "EL MABROUK", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(3999), "Seed Data" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4004), "Seed Data", "Smith", "JOHN", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4005), "Seed Data" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4007), "Seed Data", "William", "MILLER", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4009), "Seed Data" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4040), "Seed Data", "Prof", "EL MABROUK", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4041), "Seed Data" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4044), "Seed Data", "Prof", "JOHN", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4045), "Seed Data" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4049), "Seed Data", "Prof", "MILLER", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(4050), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5377), "Seed Data", "Super Administrator Description", 1, "Super Administrator", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5381), "Seed Data" },
                    { 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5384), "Seed Data", "Administrator Description", 2, "Administrator", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5386), "Seed Data" },
                    { 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5388), "Seed Data", "User Description", 3, "User", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5390), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "profcode", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5093), "Seed Data", 4, "CODE_1", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5103), "Seed Data" },
                    { 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5108), "Seed Data", 5, "CODE_2", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5109), "Seed Data" },
                    { 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5111), "Seed Data", 6, "CODE_3", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(5113), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7117), "Seed Data", 1, 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7127), "Seed Data" },
                    { 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7132), "Seed Data", 2, 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7133), "Seed Data" },
                    { 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7135), "Seed Data", 3, 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(7137), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(1972), "Seed Data", "user1@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 1, 1, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(1982), "Seed Data" },
                    { 2, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(2020), "Seed Data", "user2@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 2, 2, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(2021), "Seed Data" },
                    { 3, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(2076), "Seed Data", "user3@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 3, 3, new DateTime(2022, 1, 28, 14, 29, 43, 607, DateTimeKind.Local).AddTicks(2078), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 1, "Course 1", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9723), "Seed Data", 1, 1, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9735), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 2, "Course 2", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9740), "Seed Data", 2, 2, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9742), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 3, "Course 3", new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9744), "Seed Data", 3, 3, new DateTime(2022, 1, 28, 14, 29, 43, 606, DateTimeKind.Local).AddTicks(9745), "Seed Data" });

            migrationBuilder.CreateIndex(
                name: "IX_courses_professorid",
                table: "courses",
                column: "professorid");

            migrationBuilder.CreateIndex(
                name: "IX_courses_studentid",
                table: "courses",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_professors_personid",
                table: "professors",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_students_levelid",
                table: "students",
                column: "levelid");

            migrationBuilder.CreateIndex(
                name: "IX_students_personid",
                table: "students",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_users_personid",
                table: "users",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleid",
                table: "users",
                column: "roleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "professors");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "levels");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
