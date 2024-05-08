using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoacaoViva.Infrastructure.Database.Migrations
{
    public partial class doacaoviva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    FromName = table.Column<string>(type: "text", nullable: true),
                    FromEmailOrPhone = table.Column<string>(type: "text", nullable: true),
                    NotificationType = table.Column<int>(type: "integer", nullable: true),
                    NotificationStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Abbreviation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suports_Suports_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Suports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uuid", nullable: true),
                    IdProvince = table.Column<Guid>(type: "uuid", nullable: true),
                    IdCity = table.Column<Guid>(type: "uuid", nullable: true),
                    Neighborhood = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresss_Suports_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Suports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresss_Suports_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Suports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresss_Suports_IdProvince",
                        column: x => x.IdProvince,
                        principalTable: "Suports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    MainContact = table.Column<string>(type: "text", nullable: true),
                    SecondaryContact = table.Column<string>(type: "text", nullable: true),
                    MainEmail = table.Column<string>(type: "text", nullable: true),
                    SecondaryEmail = table.Column<string>(type: "text", nullable: true),
                    IdAddress = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Addresss_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Addresss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerson = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBloodType = table.Column<Guid>(type: "uuid", nullable: false),
                    RhFactor = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donators_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donators_Suports_IdBloodType",
                        column: x => x.IdBloodType,
                        principalTable: "Suports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPersonRequest = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequestStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Persons_IdPersonRequest",
                        column: x => x.IdPersonRequest,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailOrPhone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    IdPerson = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDonator = table.Column<Guid>(type: "uuid", nullable: true),
                    DonationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QtdMl = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Donators_IdDonator",
                        column: x => x.IdDonator,
                        principalTable: "Donators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonatorHospitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHospital = table.Column<Guid>(type: "uuid", nullable: false),
                    DonatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorHospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorHospitals_Donators_DonatorId",
                        column: x => x.DonatorId,
                        principalTable: "Donators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonatorHospitals_Suports_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "Suports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdRequest = table.Column<Guid>(type: "uuid", nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Requests_IdRequest",
                        column: x => x.IdRequest,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdHospital = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRequest = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalRequest_Requests_IdRequest",
                        column: x => x.IdRequest,
                        principalTable: "Requests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HospitalRequest_Suports_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "Suports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestBloodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdBloodType = table.Column<Guid>(type: "uuid", nullable: false),
                    Gratification = table.Column<double>(type: "double precision", nullable: true),
                    IdHospitalRequest = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestBloodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestBloodTypes_HospitalRequest_IdHospitalRequest",
                        column: x => x.IdHospitalRequest,
                        principalTable: "HospitalRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestBloodTypes_Suports_IdBloodType",
                        column: x => x.IdBloodType,
                        principalTable: "Suports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_IdCity",
                table: "Addresss",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_IdCountry",
                table: "Addresss",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_IdProvince",
                table: "Addresss",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_IdRequest",
                table: "Campaigns",
                column: "IdRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_IdDonator",
                table: "Donations",
                column: "IdDonator");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorHospitals_DonatorId",
                table: "DonatorHospitals",
                column: "DonatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorHospitals_IdHospital",
                table: "DonatorHospitals",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_Donators_IdBloodType",
                table: "Donators",
                column: "IdBloodType");

            migrationBuilder.CreateIndex(
                name: "IX_Donators_IdPerson",
                table: "Donators",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRequest_IdHospital",
                table: "HospitalRequest",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRequest_IdRequest",
                table: "HospitalRequest",
                column: "IdRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdAddress",
                table: "Persons",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_RequestBloodTypes_IdBloodType",
                table: "RequestBloodTypes",
                column: "IdBloodType");

            migrationBuilder.CreateIndex(
                name: "IX_RequestBloodTypes_IdHospitalRequest",
                table: "RequestBloodTypes",
                column: "IdHospitalRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IdPersonRequest",
                table: "Requests",
                column: "IdPersonRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Suports_ParentId",
                table: "Suports",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdPerson",
                table: "Users",
                column: "IdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "DonatorHospitals");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RequestBloodTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.DropTable(
                name: "HospitalRequest");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Suports");
        }
    }
}
