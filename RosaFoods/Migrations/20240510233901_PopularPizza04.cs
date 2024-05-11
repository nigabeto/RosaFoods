using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosaFoods.Migrations
{
    public partial class PopularPizza04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Feita com fermentação natural, molho de tomate, presunto, mussarela, ervilhas e orégano.','A Pizza de Portuguesa é coberta com molho de tomate, queijo tipo mussarela, presunto e massa com fermentação natural.',1, 'C:\\RosaFoods\\RosaFoods\\RosaFoods\\wwwroot\\Images\\pizza-portuguesa.jpg','C:\\RosaFoods\\RosaFoods\\RosaFoods\\wwwroot\\Images\\pizza-portuguesa.jpg', 0 ,'Portuguesa', 39.40)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pizzas");
        }
    }
}
