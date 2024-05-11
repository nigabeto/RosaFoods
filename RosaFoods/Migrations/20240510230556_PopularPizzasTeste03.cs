using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosaFoods.Migrations
{
    public partial class PopularPizzasTeste03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Combo especial','Monte seu combo',1, 'https://drive.google.com/file/d/1cWgfzeaavrZdE36uXAXjX9HCb__gbWT2/view?usp=sharing','https://drive.google.com/file/d/1cWgfzeaavrZdE36uXAXjX9HCb__gbWT2/view?usp=sharing', 1 ,'Combo', 70.50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pizzas");
        }
    }
}
