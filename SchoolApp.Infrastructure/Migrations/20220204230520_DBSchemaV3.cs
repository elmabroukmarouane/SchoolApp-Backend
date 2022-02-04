using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Infrastructure.Migrations
{
    public partial class DBSchemaV3 : Migration
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
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6373), "Seed Data", "Level 1", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6417), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6420), "Seed Data", "Level 2", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6421), "Seed Data" });

            migrationBuilder.InsertData(
                table: "levels",
                columns: new[] { "id", "createdate", "createdby", "levelname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6424), "Seed Data", "Level 3", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6426), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6660), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6663), "Seed Data", "Marouane", "EL MABROUK", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6665), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6669), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6671), "Seed Data", "Smith", "JOHN", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6673), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6675), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6676), "Seed Data", "William", "MILLER", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6678), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6680), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6682), "Seed Data", "Prof", "EL MABROUK", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6683), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6685), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6687), "Seed Data", "Prof", "JOHN", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6689), "Seed Data" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "birthdate", "createdate", "createdby", "firstname", "lastname", "updatedate", "updatedby" },
                values: new object[] { 6, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6691), new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6693), "Seed Data", "Prof", "MILLER", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(6695), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8612), "Seed Data", "Super Administrator Description", 1, "Super Administrator", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8619), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8623), "Seed Data", "Administrator Description", 2, "Administrator", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8624), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8627), "Seed Data", "Professor Description", 3, "Professor", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8629), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8631), "Seed Data", "Student Description", 4, "User", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8632), "Seed Data" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "createdate", "createdby", "description", "role", "title", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8635), "Seed Data", "User Description", 5, "User", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8636), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8055), "Seed Data", 4, "avatar.png", "CODE_1", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8066), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8071), "Seed Data", 5, "avatar.png", "CODE_2", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8072), "Seed Data" });

            migrationBuilder.InsertData(
                table: "professors",
                columns: new[] { "id", "createdate", "createdby", "personid", "photoprofessor", "profcode", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8075), "Seed Data", 6, "avatar.png", "CODE_3", new DateTime(2022, 2, 5, 0, 5, 20, 478, DateTimeKind.Local).AddTicks(8077), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(450), "Seed Data", 1, 1, "avatar.png", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(459), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(463), "Seed Data", 2, 2, "avatar.png", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(465), "Seed Data" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "createdate", "createdby", "levelid", "personid", "photostudent", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(467), "Seed Data", 3, 3, "avatar.png", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(468), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 1, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4642), "Seed Data", "user1@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 1, 1, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4652), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 2, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4691), "Seed Data", "user2@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 2, 2, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4694), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 3, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4727), "Seed Data", "user3@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 3, 3, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4729), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 4, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4784), "Seed Data", "user4@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 4, 4, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4787), "Seed Data" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdate", "createdby", "email", "password", "personid", "roleid", "updatedate", "updatedby" },
                values: new object[] { 5, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4818), "Seed Data", "user5@mail.com", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", 5, 5, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(4820), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 1, "Course 1", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2473), "Seed Data", 1, 1, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2483), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 2, "Course 2", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2488), "Seed Data", 2, 2, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2490), "Seed Data" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "coursename", "createdate", "createdby", "professorid", "studentid", "updatedate", "updatedby" },
                values: new object[] { 3, "Course 3", new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2492), "Seed Data", 3, 3, new DateTime(2022, 2, 5, 0, 5, 20, 479, DateTimeKind.Local).AddTicks(2494), "Seed Data" });

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
