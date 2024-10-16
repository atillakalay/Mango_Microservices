using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class min_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Fast Food", "İnce hamurun üzerine sıcak baharatlarla harmanlanmış kıyma, domates ve soğan konularak pişirilen geleneksel Türk lezzeti.", "https://placehold.co/603x403", "Lahmacun", 25.0 },
                    { 2, "Dessert", "İnce tel kadayıfın içine peynir konularak pişirilir ve üzerine şerbet dökülür. Türkiye'nin en sevilen tatlılarından biri.", "https://placehold.co/602x402", "Künefe", 35.0 },
                    { 3, "Main Course", "İnce dilimlenmiş dana eti, tava da pişirilir ve pide ekmeği üzerine dökülür. Üzerine yoğurt ve domates sosu dökülür.", "https://placehold.co/601x401", "İskender Kebap", 50.0 },
                    { 4, "Dessert", "İnce yufkalar arasına fıstık konularak yapılan ve şerbet ile tatlandırılan geleneksel Türk tatlısı.", "https://placehold.co/600x400", "Baklava", 40.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
