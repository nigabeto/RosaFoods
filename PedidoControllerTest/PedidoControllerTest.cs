using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using RosaFoods.Controllers;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;
using System.Collections.Generic;
using RosaFoods.Context;
using Microsoft.EntityFrameworkCore;

namespace PedidoControllerTest
{
    public class PedidoControllerTest
    {
        [Fact(DisplayName = "Calcular Total do pedido com sucesso")]
        public void Checkout_Deve_Calcular_TotalPedido_Corretamente()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Criando o contexto usando o InMemoryDatabase
            using var context = new AppDbContext(options);

            var mockPedidoRepository = new Mock<IPedidoRepository>();

            // Criando uma inst�ncia real de CarrinhoCompra com o contexto InMemory
            var carrinhoCompra = new CarrinhoCompra(context);

            // Adicionando itens ao carrinho de compras
            var itensCarrinho = new List<CarrinhoCompraItem>
            {
                new CarrinhoCompraItem
                {
                    Quantidade = 2,
                    Pizza = new Pizza
                    {
                        Nome = "Marguerita",
                        Preco = 30.00m,
                        DescricaoCurta = "Pizza Marguerita",
                        DescricaoDetalhada = "Pizza Margherita com molho de tomate, mussarela e manjeric�o."
                    }
                },
                new CarrinhoCompraItem
                {
                    Quantidade = 1,
                    Pizza = new Pizza
                    {
                        Nome = "Pepperoni",
                        Preco = 40.00m,
                        DescricaoCurta = "Pizza Pepperoni",
                        DescricaoDetalhada = "Pizza Pepperoni com molho de tomate e fatias de pepperoni."
                    }
                }
            };

            // Adicionando os itens diretamente ao contexto para simular um carrinho "real"
            context.CarrinhoCompraItens.AddRange(itensCarrinho);
            context.SaveChanges();

            carrinhoCompra.CarrinhoCompraItems = itensCarrinho;

            var controller = new PedidoController(mockPedidoRepository.Object, carrinhoCompra);
            var pedido = new Pedido();

            // Act
            var result = controller.Checkout(pedido) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = result.Model as Pedido;
            Assert.Equal(3, model.TotalItensPedido); // 2 pizzas Marguerita + 1 Pepperoni
            Assert.Equal(100.00m, model.PedidoTotal); // Total esperado
        }
    }
}
