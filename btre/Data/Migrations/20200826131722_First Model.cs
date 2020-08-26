using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace btre.Data.Migrations
{
    public partial class FirstModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsMvp = table.Column<bool>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Bedrooms = table.Column<int>(nullable: false),
                    Bathrooms = table.Column<int>(nullable: false),
                    Garage = table.Column<int>(nullable: false),
                    Sqft = table.Column<int>(nullable: false),
                    LotSize = table.Column<decimal>(nullable: false),
                    PhotoMain = table.Column<string>(nullable: true),
                    Photo1 = table.Column<string>(nullable: true),
                    Photo2 = table.Column<string>(nullable: true),
                    Photo3 = table.Column<string>(nullable: true),
                    Photo4 = table.Column<string>(nullable: true),
                    Photo5 = table.Column<string>(nullable: true),
                    Photo6 = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    ListDate = table.Column<DateTime>(nullable: true),
                    RealtorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Realtor_RealtorId",
                        column: x => x.RealtorId,
                        principalTable: "Realtor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealtorId",
                table: "Listings",
                column: "RealtorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Realtor");
        }
    }
}
