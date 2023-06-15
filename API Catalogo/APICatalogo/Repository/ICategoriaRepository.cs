using APICatalogo.Models;
using APICatalogo.Repository;
using System.Collections.Generic;

namespace ApiCatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
