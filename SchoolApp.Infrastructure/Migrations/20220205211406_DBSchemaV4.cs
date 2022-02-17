using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Infrastructure.Migrations
{
    public partial class DBSchemaV4 : Migration
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
                    isOnline = table.Column<bool>(type: "INTEGER", nullable: false),
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
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4118), "Seed Data", "Level 1", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4306), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4320), "Seed Data", "Level 2", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4322), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4324), "Seed Data", "Level 3", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4326), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4711), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4715), "Seed Data", "Marouane", "EL MABROUK", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4717), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4723), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4724), "Seed Data", "Smith", "JOHN", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4726), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4729), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4730), "Seed Data", "William", "MILLER", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4736), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4739), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4740), "Seed Data", "Prof", "EL MABROUK", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4742), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4744), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4746), "Seed Data", "Prof", "JOHN", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4748), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 6, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4752), new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4753), "Seed Data", "Prof", "MILLER", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(4755), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6675), "Seed Data", "Super Administrator Description", 1, "Super Administrator", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6679), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6683), "Seed Data", "Administrator Description", 2, "Administrator", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6685), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6688), "Seed Data", "Professor Description", 3, "Professor", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6689), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6692), "Seed Data", "Student Description", 4, "User", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6694), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6696), "Seed Data", "User Description", 5, "User", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6698), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6366), "Seed Data", 4, "avatar.png", "CODE_1", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6378), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6385), "Seed Data", 5, "avatar.png", "CODE_2", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6387), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6389), "Seed Data", 6, "avatar.png", "CODE_3", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(6391), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8613), "Seed Data", 1, 1, "avatar.png", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8624), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8629), "Seed Data", 2, 2, "avatar.png", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8631), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8633), "Seed Data", 3, 3, "avatar.png", new DateTime(2022, 2, 5, 22, 14, 6, 196, DateTimeKind.Local).AddTicks(8635), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "isOnline", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2675), "Seed Data", "user1@mail.com", false, "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 1, 1, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2686), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "isOnline", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2766), "Seed Data", "user2@mail.com", false, "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 2, 2, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2769), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "isOnline", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2807), "Seed Data", "user3@mail.com", false, "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 3, 3, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2809), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "isOnline", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2871), "Seed Data", "user4@mail.com", false, "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 4, 4, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2873), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "isOnline", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2910), "Seed Data", "user5@mail.com", false, "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 5, 5, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(2912), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 1, "Course 1", new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(529), "Seed Data", 1, 1, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(540), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 2, "Course 2", new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(579), "Seed Data", 2, 2, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(581), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 3, "Course 3", new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(584), "Seed Data", 3, 3, new DateTime(2022, 2, 5, 22, 14, 6, 197, DateTimeKind.Local).AddTicks(586), "Seed Data" });

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
