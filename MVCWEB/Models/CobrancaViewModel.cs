using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCWEB.Models
{
    public class CobrancaViewModel
    {
        public int CobrancaId { get; set; }

        [Display(Name = "Data da Cobrança")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCobranca { get; set; }

        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "ID do Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Valor da Cobrança")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorCobranca { get; set; }

        [Display(Name = "Informações Adicionais")]
        public string InformacoesAdicionais { get; set; }
    }

}