using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoProduto
    {
        Task AdicionaProduto(Produto produto);
        Task AtualizaProduto(Produto produto);
        Task<List<Produto>> ListarProdutosAtivos();

        Task ExcluirProduto(Produto produto);
    }
}
