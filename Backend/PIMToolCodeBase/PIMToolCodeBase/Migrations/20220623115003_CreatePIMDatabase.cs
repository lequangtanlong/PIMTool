﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIMToolCodeBase.Migrations
{
    public partial class CreatePIMDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VISA = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BIRTH_DAY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VERSION = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_LEADER_ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false),
                    VERSION = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GROUP_EMPLOYEE_GROUP_LEADER_ID",
                        column: x => x.GROUP_LEADER_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false),
                    PROJECT_NUMBER = table.Column<decimal>(type: "numeric(4,0)", precision: 4, scale: 0, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CUSTOMER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VERSION = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT", x => x.ID);
                    table.CheckConstraint("CK_Project_Status", "[STATUS] IN ('NEW', 'PLA', 'INP', 'FIN')");
                    table.ForeignKey(
                        name: "FK_PROJECT_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "GROUP",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_EMPLOYEE",
                columns: table => new
                {
                    PROJECT_ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false),
                    EMPLOYEE_ID = table.Column<decimal>(type: "numeric(19,0)", precision: 19, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_EMPLOYEE", x => new { x.PROJECT_ID, x.EMPLOYEE_ID });
                    table.ForeignKey(
                        name: "FK_PROJECT_EMPLOYEE_EMPLOYEE_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PROJECT_EMPLOYEE_PROJECT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_GROUP_LEADER_ID",
                table: "GROUP",
                column: "GROUP_LEADER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_GROUP_ID",
                table: "PROJECT",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_PROJECT_NUMBER",
                table: "PROJECT",
                column: "PROJECT_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_EMPLOYEE_EMPLOYEE_ID",
                table: "PROJECT_EMPLOYEE",
                column: "EMPLOYEE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROJECT_EMPLOYEE");

            migrationBuilder.DropTable(
                name: "PROJECT");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");
        }
    }
}
