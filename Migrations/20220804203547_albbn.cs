using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Migrations
{
    public partial class albbn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "TbCategoriesCategoryId",
                table: "TbItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbItemImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbItemImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_TbItemImages_TbItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "TbItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItemImages_ItemId",
                table: "TbItemImages",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems",
                column: "TbCategoriesCategoryId",
                principalTable: "TbCategories",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "TbCategoriesCategoryId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems",
                column: "TbCategoriesCategoryId",
                principalTable: "TbCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
