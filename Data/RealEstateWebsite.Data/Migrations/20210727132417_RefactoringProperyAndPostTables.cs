namespace RealEstateWebsite.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RefactoringProperyAndPostTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PropertyTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Properties",
                newName: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Posts",
                newName: "EstateAgentId");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Interior",
                table: "Properties",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LivingArea",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EstateAgentId",
                table: "Posts",
                column: "EstateAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_RealEstateAgents_EstateAgentId",
                table: "Posts",
                column: "EstateAgentId",
                principalTable: "RealEstateAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_RealEstateAgents_EstateAgentId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_EstateAgentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Interior",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LivingArea",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Rooms",
                table: "Properties",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "EstateAgentId",
                table: "Posts",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTag",
                columns: table => new
                {
                    PropertiesId = table.Column<int>(type: "int", nullable: false),
                    PropertyTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTag", x => new { x.PropertiesId, x.PropertyTagsId });
                    table.ForeignKey(
                        name: "FK_PropertyTag_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyTag_Tags_PropertyTagsId",
                        column: x => x.PropertyTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTag_PropertyTagsId",
                table: "PropertyTag",
                column: "PropertyTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IsDeleted",
                table: "Tags",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
