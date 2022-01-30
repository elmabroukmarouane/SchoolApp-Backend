using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Infrastructure.Migrations
{
    public partial class DBSchemaV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    levelname = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "TEXT", nullable: true),
                    lastname = table.Column<string>(type: "TEXT", nullable: true),
                    birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role = table.Column<int>(type: "INTEGER", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professors",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    personid = table.Column<int>(type: "INTEGER", nullable: false),
                    profcode = table.Column<string>(type: "TEXT", nullable: true),
                    photoprofessor = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    personid = table.Column<int>(type: "INTEGER", nullable: false),
                    levelid = table.Column<int>(type: "INTEGER", nullable: false),
                    photostudent = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    roleid = table.Column<int>(type: "INTEGER", nullable: false),
                    personid = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentid = table.Column<int>(type: "INTEGER", nullable: false),
                    professorid = table.Column<int>(type: "INTEGER", nullable: false),
                    coursename = table.Column<string>(type: "TEXT", nullable: true),
                    createdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updatedate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    createdby = table.Column<string>(type: "TEXT", nullable: true),
                    updatedby = table.Column<string>(type: "TEXT", nullable: true)
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
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5948), "Seed Data", "Level 1", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5987), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5991), "Seed Data", "Level 2", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5993), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5996), "Seed Data", "Level 3", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(5997), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6192), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6194), "Seed Data", "Marouane", "EL MABROUK", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6197), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6201), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6203), "Seed Data", "Smith", "JOHN", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6204), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6206), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6208), "Seed Data", "William", "MILLER", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6210), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6212), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6214), "Seed Data", "Prof", "EL MABROUK", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6215), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6217), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6218), "Seed Data", "Prof", "JOHN", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6220), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 6, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6224), new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6226), "Seed Data", "Prof", "MILLER", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(6226), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8071), "Seed Data", "Super Administrator Description", 1, "Super Administrator", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8076), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8079), "Seed Data", "Administrator Description", 2, "Administrator", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8081), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8083), "Seed Data", "User Description", 3, "User", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(8085), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7784), "Seed Data", 4, "avatar.png", "CODE_1", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7796), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7799), "Seed Data", 5, "avatar.png", "CODE_2", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7801), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7804), "Seed Data", 6, "avatar.png", "CODE_3", new DateTime(2022, 1, 30, 12, 0, 16, 48, DateTimeKind.Local).AddTicks(7806), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(25), "Seed Data", 1, 1, "avatar.png", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(36), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(40), "Seed Data", 2, 2, "avatar.png", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(41), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(44), "Seed Data", 3, 3, "avatar.png", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(46), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(3947), "Seed Data", "user1@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 1, 1, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(3956), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(3994), "Seed Data", "user2@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 2, 2, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(3997), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(4029), "Seed Data", "user3@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 3, 3, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(4032), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 1, "Course 1", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2053), "Seed Data", 1, 1, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2064), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 2, "Course 2", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2069), "Seed Data", 2, 2, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2071), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 3, "Course 3", new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2074), "Seed Data", 3, 3, new DateTime(2022, 1, 30, 12, 0, 16, 49, DateTimeKind.Local).AddTicks(2075), "Seed Data" });

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
