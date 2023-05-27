using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Migrations
{
    public partial class TbCate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TbCategoriesCategoryId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TbCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItems_TbCategoriesCategoryId",
                table: "TbItems",
                column: "TbCategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems",
                column: "TbCategoriesCategoryId",
                principalTable: "TbCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbCategories");

            migrationBuilder.DropIndex(
                name: "IX_TbItems_TbCategoriesCategoryId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "TbCategoriesCategoryId",
                table: "TbItems");
        }
    }
}
