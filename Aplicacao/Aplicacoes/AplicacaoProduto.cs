using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoProduto : IAplicacaoProduto
    {
        IProduto _produto;
        IServicoProduto _servicoProduto;
        public AplicacaoProduto(IProduto IProduto, IServicoProduto servicoProduto)
        {
            _produto = IProduto;
            _servicoProduto = servicoProduto;
        }
        public async Task AdicionaProduto(Produto produto)
        {
            await _servicoProduto.AdicionaProduto(produto);
        }
        public async Task AtualizaProduto(Produto produto)
        {
            await _servicoProduto.AtualizaProduto(produto);
        }

        public async Task<List<Produto>> ListarProdutosAtivos()
        {
            return await _servicoProduto.ListarProdutosAtivos();
        }

        public async Task ExcluirProduto(Produto produto)
        {
            await _servicoProduto.ExcluirProduto(produto);
        }
        public async Task Adicionar(Produto obj)
        {
            await _produto.Adicionar(obj);
        }

        public async Task Atualizar(Produto obj)
        {
            await _produto.Atualizar(obj);
        }

        public async Task<Produto> BuscarPorId(int id)
        {
           return await _produto.BuscarPorId(id);
        }

        public async Task Excluir(Produto obj)
        {
            await _produto.Excluir(obj);
        }

        public async Task<List<Produto>> Listar()
        {
            return await _produto.Listar();
        }

        
    }
}
