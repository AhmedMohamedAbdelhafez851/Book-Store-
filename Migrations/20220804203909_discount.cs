using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Migrations
{
    public partial class discount : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "TbItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TbItemDiscount",
                columns: table => new
                {
                    ItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TbItemsItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbItemDiscount", x => x.ItemDiscountId);
                    table.ForeignKey(
                        name: "FK_TbItemDiscount_TbItems_TbItemsItemId",
                        column: x => x.TbItemsItemId,
                        principalTable: "TbItems",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItemDiscount_TbItemsItemId",
                table: "TbItemDiscount",
                column: "TbItemsItemId");

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
                name: "TbItemDiscount");

            migrationBuilder.AlterColumn<int>(
                name: "TbCategoriesCategoryId",
                table: "TbItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbCategories_TbCategoriesCategoryId",
                table: "TbItems",
                column: "TbCategoriesCategoryId",
                principalTable: "TbCategories",
                principalColumn: "CategoryId");
        }
    }
}
