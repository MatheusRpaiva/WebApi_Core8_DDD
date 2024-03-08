using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoProdutos : IServicoProduto
    {
        private readonly IProduto _IProduto;

        public ServicoProdutos(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        public async Task AdicionaProduto(Produto produto)
        {
            var validarDescricao = produto.ValidarPropriedadeString(produto.DescricaoProduto, "Descricao");
            var validarData = produto.ValidarDataFabricacao(produto.DataFabricacao, produto.DataValidade);
            if (validarDescricao && validarData)
            {
                produto.Ativo = true;
                await _IProduto.Adicionar(produto);
            }
        }

        public async Task AtualizaProduto(Produto produto)
        {
            var validarDescricao = produto.ValidarPropriedadeString(produto.DescricaoProduto, "Descricao");
            var validarCodigo = produto.ValidarPropriedadeInt(produto.Id, "Id");
            var validarData = produto.ValidarDataFabricacao(produto.DataFabricacao, produto.DataValidade);
            if (validarDescricao && validarCodigo && validarData)
            {
                produto.Ativo = true;
                await _IProduto.Atualizar(produto);
            }
        }

        public async Task ExcluirProduto(Produto produto)
        {
            var validarCodigo = produto.ValidarPropriedadeInt(produto.Id, "Id");
            if (validarCodigo)
            {
                produto.Ativo = false;
                await _IProduto.Atualizar(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosAtivos()
        {
            return await _IProduto.ListarProdutos(p => p.Ativo);
        }


    }
}
