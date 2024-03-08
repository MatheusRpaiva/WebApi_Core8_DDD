using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WEB_API_AUTOGLASS.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WEB_API_AUTOGLASS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IAplicacaoProduto _AplicacaoProduto;

        public ProdutoController(IAplicacaoProduto IAplicacaoProduto)
        {
            _AplicacaoProduto = IAplicacaoProduto;
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarProdutos")]
        public async Task<List<Produto>> ListarProdutos(string? filtro, int page = 1, int pageSize = 10)
        {
            var produtos = await _AplicacaoProduto.ListarProdutosAtivos();
            if (!string.IsNullOrEmpty(filtro))
            {
                produtos = produtos.Where(p => p.DescricaoProduto.Contains(filtro)).ToList();
            }

            // Paginação
            var totalCount = produtos.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return produtos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionaProduto")]
        public async Task<List<Notifica>> AdicionaProduto(ProdutoModel produtoModel)
        {
            var novoProduto = new Produto();
            novoProduto.DescricaoProduto = produtoModel.DescricaoProduto;
            novoProduto.DataFabricacao = produtoModel.DataFabricacao;
            novoProduto.DataValidade = produtoModel.DataValidade;
            novoProduto.DescricaoFornecedor = produtoModel.DescricaoFornecedor;
            novoProduto.CNPJ = produtoModel.CNPJFornecedor;
            await _AplicacaoProduto.AdicionaProduto(novoProduto);

            return novoProduto.Notificacoes;

        }

        [Produces("application/json")]
        [HttpPut("/api/AtualizaProduto")]
        public async Task<List<Notifica>> AtualizaProduto(ProdutoModel produtoModel)
        {
            var novoProduto = await _AplicacaoProduto.BuscarPorId(produtoModel.IdProduto);
            novoProduto.DescricaoProduto = produtoModel.DescricaoProduto;
            novoProduto.DataFabricacao = produtoModel.DataFabricacao;
            novoProduto.DataValidade = produtoModel.DataValidade;
            novoProduto.DescricaoFornecedor = produtoModel.DescricaoFornecedor;
            novoProduto.CNPJ = produtoModel.CNPJFornecedor;
            await _AplicacaoProduto.AtualizaProduto(novoProduto);

            return novoProduto.Notificacoes;

        }

        [Produces("application/json")]
        [HttpDelete("/api/ExcluiProduto")]
        public async Task<List<Notifica>> ExcluiProduto([FromBody] int CodigoProduto)
        {
            var novoProduto = await _AplicacaoProduto.BuscarPorId(CodigoProduto);
            await _AplicacaoProduto.ExcluirProduto(novoProduto);

            return novoProduto.Notificacoes;

        }
        [Produces("application/json")]
        [HttpGet("/api/BuscarPorId")]
        public async Task<Produto> BuscarPorId(int CodigoProduto)
        {
            return await _AplicacaoProduto.BuscarPorId(CodigoProduto);
           
        }
    }
}
