using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosaFoods.Migrations
{
    public partial class PopularPizzas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Feita com fermentação natural, molho de tomate rústico, mussarela tradicional e orégano.','A Pizza de Mussarela é coberta com molho de tomate, queijo tipo mussarela, azeitonas pretas e orégano e massa com fermentação natural.',1, '~/Images/pizza-mussarela.jpg','~/Images/pizza-mussarela.jpg', 1 ,'Mussarela', 30.50)");
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Feita com farinha de trigo, linguiça calabresa, cebola, azeitona e orégano','Combinação de Linguiça Calabresa, rodelas de cebolas frescas, azeitonas pretas, mussarela, polpa de tomate, orégano e massa especial.',1, '~/Images/pizza-calabresa.jpg','~/Images/pizza-calabresa.jpg', 1 ,'Calabresa', 35.70)");
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(1,'Feita com farinha de trigo, mussarela de búfala, tomate, queijo parmesão, azeite de oliva, manjericão, sal e fermento biológico.','Composta pelos ingredientes Farinha, água, sal e fermento e molho de tomate San Marzano, muçarela de búfala, azeite de oliva extra virgem e manjericão.',1, '~/Images/marguerita.jpg','~/Images/marguerita.jpg', 1 ,'Marguerita', 41.90)");
            migrationBuilder.Sql("INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) " +
                "VALUES(2,'Mistura frutas como abacaxi, pêssego, figo, ameixa e cereja','Deliciosa pizza leve,  molho caseiro feito com muçarela e lombo canadense, bananas caramelizadas, figos, pêssegos, abacaxi e cerejas. ',1, '~/Images/morango.jpg','~/Images/morango.jpg', 0 ,'California', 55.80)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("DELETE FROM Pizzas");
        }
    }
}
