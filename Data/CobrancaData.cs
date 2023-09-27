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
    public class CobrancaData : IDataAdmin<Cobranca>
    {
        private readonly Acesso _acessoDataDapper;

        public CobrancaData()
        {
            _acessoDataDapper = new Acesso();
        }

        public void Inserir(Cobranca cobranca)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            INSERT INTO Cobrancas (DataCobranca, ClienteID, ProdutoID, ValorCobranca, InformacoesAdicionais)
            VALUES (@DataCobranca, @ClienteID, @ProdutoID, @ValorCobranca, @InformacoesAdicionais)",
                new
                {
                    cobranca.DataCobranca,
                    cobranca.ClienteID,
                    cobranca.ProdutoID,
                    cobranca.ValorCobranca,
                    cobranca.InformacoesAdicionais
                });
        }

        public Cobranca BuscarPorId(int cobrancaID)
        {
            return _acessoDataDapper.dbConnectiondbConnection.QueryFirstOrDefault<Cobranca>(@"
                SELECT 
                        C.CobrancaID, 
                        C.DataCobranca, 
                        C.ClienteID, 
                        C.ProdutoID, 
                        C.ValorCobranca, 
                        C.InformacoesAdicionais,
                        P.Nome AS NomeProduto,
                        Cl.Nome AS NomeCliente
                    FROM Cobrancas AS C
                    INNER JOIN Produtos AS P ON C.ProdutoID = P.ProdutoID
                    INNER JOIN Cliente AS Cl ON C.ClienteID = Cl.ClienteID
            WHERE  C.CobrancaID = @CobrancaID", new { CobrancaID = cobrancaID });
        }

        public IEnumerable<Cobranca> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Cobranca>(@"
                    SELECT 
                        C.CobrancaID, 
                        C.DataCobranca, 
                        C.ClienteID, 
                        C.ProdutoID, 
                        C.ValorCobranca, 
                        C.InformacoesAdicionais,
                        P.Nome AS NomeProduto,
                        Cl.Nome AS NomeCliente
                    FROM Cobrancas AS C
                    INNER JOIN Produtos AS P ON C.ProdutoID = P.ProdutoID
                    INNER JOIN Cliente AS Cl ON C.ClienteID = Cl.ClienteID");
        }

        public void Atualizar(Cobranca cobranca)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            UPDATE Cobrancas
            SET DataCobranca = @DataCobranca, ClienteID = @ClienteID, ProdutoID = @ProdutoID,
                ValorCobranca = @ValorCobranca, InformacoesAdicionais = @InformacoesAdicionais
            WHERE CobrancaID = @CobrancaID",
                new
                {
                    cobranca.CobrancaID,
                    cobranca.DataCobranca,
                    cobranca.ClienteID,
                    cobranca.ProdutoID,
                    cobranca.ValorCobranca,
                    cobranca.InformacoesAdicionais
                });
        }

        public void Excluir(int cobrancaID)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
            DELETE FROM Cobrancas
            WHERE CobrancaID = @CobrancaID", new { CobrancaID = cobrancaID });
        }
    }
}
