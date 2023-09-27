using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cobranca
    {
        public int CobrancaID { get; set; } 

        public DateTime DataCobranca { get; set; }

        public int ClienteID { get; set; } 

        public int ProdutoID { get; set; } 

        public decimal ValorCobranca { get; set; }

        public string InformacoesAdicionais { get; set; }

        public string NomeProduto { get; set; }
        public string NomeCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Produto Produto { get; set; }
    }

}
