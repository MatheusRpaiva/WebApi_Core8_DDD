using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WEB_API_AUTOGLASS.Model
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataFabricacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set;}
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }

    }
}
