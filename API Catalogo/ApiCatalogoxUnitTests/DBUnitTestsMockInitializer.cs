using APICatalogo.Context;
using APICatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoxUnitTests
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        {}
        public void Seed(ApiDbContext context)
        {
            context.Produtos.Add
            (new Produto { Nome = "bebidas 999", Descricao = "Bebidas 999", Preco = 3, ImagemUrl = "Bebidas 999", Estoque = 11, DataCadastro = DateTime.Now, CategoriaId = 1 });

            context.Produtos.Add
            (new Produto { Nome = "comidas 999", Descricao = "comidas 999", Preco = 3, ImagemUrl = "comidas 999", Estoque = 6, DataCadastro = DateTime.Now, CategoriaId = 2 });

            context.Produtos.Add
            (new Produto { Nome = "doces 999", Descricao = "doces 999", Preco = 3, ImagemUrl = "doces 999", Estoque = 8, DataCadastro = DateTime.Now, CategoriaId = 1});

            context.SaveChanges();
        }
    }
}
