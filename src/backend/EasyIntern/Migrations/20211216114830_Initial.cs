using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyIntern.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternshipPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    EmployeeSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internships_Interns_InternId",
                        column: x => x.InternId,
                        principalTable: "Interns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_InternshipPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "InternshipPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipAdvertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyLogo = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    InternshipPeriod_Starting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipPeriod_Ending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipId = table.Column<int>(type: "int", nullable: true),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipAdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipAdvertisements_InternshipPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "InternshipPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipAdvertisements_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InternshipAdvertisements_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InternshipApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternshipAdvertisementId = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipApplications_Interns_InternId",
                        column: x => x.InternId,
                        principalTable: "Interns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipApplications_InternshipAdvertisements_InternshipAdvertisementId",
                        column: x => x.InternshipAdvertisementId,
                        principalTable: "InternshipAdvertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipApplications_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternshipAdvertisements_InternshipId",
                table: "InternshipAdvertisements",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipAdvertisements_OrganisationId",
                table: "InternshipAdvertisements",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipAdvertisements_PositionId",
                table: "InternshipAdvertisements",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipApplications_InternId",
                table: "InternshipApplications",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipApplications_InternshipAdvertisementId",
                table: "InternshipApplications",
                column: "InternshipAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipApplications_InternshipId",
                table: "InternshipApplications",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_InternId",
                table: "Internships",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_OrganisationId",
                table: "Internships",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_PositionId",
                table: "Internships",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternshipApplications");

            migrationBuilder.DropTable(
                name: "InternshipAdvertisements");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "InternshipPositions");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
