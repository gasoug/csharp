using APICatalogo.Context;
using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Pagination;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace APICatalogo.Controllers
{
    //no retorno da requisição é possível escolher 3 retornos, mas o padrão é o json, esse produces, coloca apenas o json como opção
    [ApiConventionType(typeof(DefaultApiConventions))]
    //Para habilitar o esquema de autenticação por token definido no Program.cs
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork contexto)
        {
            _uof = contexto;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
        {
            return _uof.ProdutoRepository.GetProdutosPorPreco().ToList();
        }

        [HttpGet]
        //[ServiceFilter(typeof(ApiLoggingFilter))]
        [EnableCors("PermitirRequest")]
        public async Task<ActionResult<IEnumerable<Produto>>> Get([FromQuery] ProdutosParameters produtosParameters)
        { 
            var produtos = await _uof.ProdutoRepository.GetProdutos(produtosParameters);

            var metadata = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            if (produtos is null)
            {
                return BadRequest("Produtos não encontrados.");
            }
            return produtos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Código do Produto</param>
        /// <returns>Objetos Produto</returns>
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name="ObterProduto")]
        public ActionResult<Produto>Get([FromQuery]int id)
        {
            //throw new Exception("Exception ao retornar o produto pelo id");

            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
        

            if (produto is null) 
            {
                return NotFound();
            }
            return produto;
        }

        /// <summary>
        /// Inclui um novo Produto
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     POST produtos
        ///     {
        ///         "Nome":"produto tal"
        ///         "Descricao":"descrição produto"
        ///         "Preco": 3.89
        ///         "ImagemUrl":"imagem.jpeg"
        ///         "Estoque": 11
        ///         "DataCadastro":"16/05/1995 23:00:00" 
        ///         "CategoriaId":"1" 
        ///     }
        /// </remarks>
        /// <param name="produto">objeto Produto</param>
        /// <returns>O objeto incluído</returns>
        /// <remarks>Retorna um objeto Produto incluído</remarks>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }
            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId}, produto);
        }
        [HttpPut("{id}")]
        //CONVENÇÕES = equivalente a passar cada código no producesresponsetype
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }
            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();

            return produto;
        }
    }
}
