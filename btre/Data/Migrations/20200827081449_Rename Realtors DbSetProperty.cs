using Microsoft.EntityFrameworkCore.Migrations;

namespace btre.Data.Migrations
{
    public partial class RenameRealtorsDbSetProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Realtor_RealtorId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realtor",
                table: "Realtor");

            migrationBuilder.RenameTable(
                name: "Realtor",
                newName: "Realtors");

            migrationBuilder.AlterColumn<bool>(
                name: "IsMvp",
                table: "Realtors",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realtors",
                table: "Realtors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Realtors_RealtorId",
                table: "Listings",
                column: "RealtorId",
                principalTable: "Realtors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Realtors_RealtorId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realtors",
                table: "Realtors");

            migrationBuilder.RenameTable(
                name: "Realtors",
                newName: "Realtor");

            migrationBuilder.AlterColumn<bool>(
                name: "IsMvp",
                table: "Realtor",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realtor",
                table: "Realtor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Realtor_RealtorId",
                table: "Listings",
                column: "RealtorId",
                principalTable: "Realtor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
