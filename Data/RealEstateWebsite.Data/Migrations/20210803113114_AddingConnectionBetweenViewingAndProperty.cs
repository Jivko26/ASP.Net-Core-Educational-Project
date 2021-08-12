namespace RealEstateWebsite.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingConnectionBetweenViewingAndProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Viewings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Viewings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Viewings_AuthorId",
                table: "Viewings",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewings_PropertyId",
                table: "Viewings",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viewings_AspNetUsers_AuthorId",
                table: "Viewings",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viewings_Properties_PropertyId",
                table: "Viewings",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewings_AspNetUsers_AuthorId",
                table: "Viewings");

            migrationBuilder.DropForeignKey(
                name: "FK_Viewings_Properties_PropertyId",
                table: "Viewings");

            migrationBuilder.DropIndex(
                name: "IX_Viewings_AuthorId",
                table: "Viewings");

            migrationBuilder.DropIndex(
                name: "IX_Viewings_PropertyId",
                table: "Viewings");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Viewings");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Viewings");
        }
    }
}
