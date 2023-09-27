using Dapper;
using Data.Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProdutoData : IDataAdmin<Produto>
    {
        private readonly Acesso _acessoDataDapper;

        public ProdutoData()
        {
            _acessoDataDapper = new Acesso();
        }

        public void Atualizar(Produto produto)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            UPDATE Produtos SET 
                [Nome] = @Nome,
                [PrecoBase] = @PrecoBase,
                [Descricao] = @Descricao
            WHERE ProdutoId = @ProdutoId",
                new
                {
                    produto.Nome,
                    produto.PrecoBase,
                    produto.ProdutoId,
                    produto.Descricao
                });
        }

        public Produto BuscarPorId(int ProdutoId)
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Produto>(@"
            SELECT [ProdutoId],
                   [Nome],
                   [PrecoBase],
                   [Descricao]
              FROM [dbo].[Produtos]
            WHERE ProdutoId = @ProdutoId", new { ProdutoId }).FirstOrDefault();
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Produto>(@"
            SELECT [ProdutoId],
                   [Nome],
                   [PrecoBase],
                   [Descricao]
              FROM [dbo].[Produtos]");
        }

        public void Excluir(int ProdutoId)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            DELETE FROM [dbo].[Produtos]
            WHERE ProdutoId = @ProdutoId", new { ProdutoId });
        }

        public void Inserir(Produto produto)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            INSERT INTO [dbo].[Produtos]
                   ([Nome],
                    [PrecoBase],
                    [Descricao])
             VALUES
                   (@Nome,
                    @PrecoBase,
                    @Descricao)",
                new
                {
                    produto.Nome,
                    produto.PrecoBase,
                    produto.Descricao
                });
        }
    }

}
