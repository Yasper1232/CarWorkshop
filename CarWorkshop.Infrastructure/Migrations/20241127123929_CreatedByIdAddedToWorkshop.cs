using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace CarWorkshop.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class CreatedByIdAddedToWorkshop : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "CreatedById",
				table: "CarWorkshop",
				type: "nvarchar(450)",
				nullable: true);
			migrationBuilder.CreateIndex(
				name: "IX_CarWorkshops_CreatedById",
				table: "CarWorkshop",
				column: "CreatedById");
			migrationBuilder.AddForeignKey(
				name: "FK_CarWorkshops_AspNetUsers_CreatedById",
				table: "CarWorkshop",
				column: "CreatedById",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}
		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_CarWorkshops_AspNetUsers_CreatedById",
				table: "CarWorkshop");
			migrationBuilder.DropIndex(
				name: "IX_CarWorkshops_CreatedById",
				table: "CarWorkshop");
			migrationBuilder.DropColumn(
				name: "CreatedById",
				table: "CarWorkshop");
		}
	}
}