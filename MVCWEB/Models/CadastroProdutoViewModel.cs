using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWEB.Models
{
    public class CadastroProdutoViewModel
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        // Outras propriedades relacionadas a Produto, se necessário

        public static implicit operator CadastroProdutoViewModel(Produto produto)
        {
            return new CadastroProdutoViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                PrecoBase = produto.PrecoBase,
            };
        }
    }

}