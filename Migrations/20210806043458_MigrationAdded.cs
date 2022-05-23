using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace PostGreBE.Migrations
{
    public partial class MigrationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecID = table.Column<string>(maxLength: 50, nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    ParentCompanyId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    PartnerId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    ActivationName = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Source = table.Column<string>(maxLength: 50, nullable: true),
                    Territory = table.Column<string>(maxLength: 50, nullable: true),
                    Revenue = table.Column<string>(maxLength: 50, nullable: true),
                    Employees = table.Column<string>(maxLength: 50, nullable: true),
                    IndCode = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneCountryCode = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneAreaCode = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    FaxCountryCode = table.Column<string>(maxLength: 50, nullable: true),
                    FaxAreaCode = table.Column<string>(maxLength: 50, nullable: true),
                    FaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    BillingCompany = table.Column<string>(maxLength: 1, nullable: true),
                    MailRestriction = table.Column<byte>(nullable: true),
                    Renewal = table.Column<byte>(nullable: true),
                    Subscription = table.Column<byte>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 450, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Age = table.Column<float>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
