using Business.Interfaces;
using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly ProdutoData produtoData;

        public ProdutoBusiness()
        {
            produtoData = new ProdutoData();
        }

        public void Atualizar(Produto produto)
        {
            produtoData.Atualizar(produto);
        }

        public Produto BuscarPorId(int id)
        {
            return produtoData.BuscarPorId(id);
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            try
            {
                return produtoData.BuscarTodos();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            produtoData.Excluir(id);
        }

        public void Inserir(Produto produto)
        {
            produtoData.Inserir(produto);
        }
    }

}
