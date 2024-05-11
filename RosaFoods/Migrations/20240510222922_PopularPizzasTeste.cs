using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosaFoods.Migrations
{
    public partial class PopularPizzasTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Feita com fermentação natural, molho de tomate, presunto, mussarela tradicional e orégano.','A Pizza de Presunto é coberta com molho de tomate, queijo tipo mussarela, presunto e massa com fermentação natural.',1, 'RosaFoods/wwwroot/Images/presunto.jpg','RosaFoods/wwwroot/Images/presunto.jpg', 1 ,'Presunto', 40.50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pizzas");
        }
    }
}
