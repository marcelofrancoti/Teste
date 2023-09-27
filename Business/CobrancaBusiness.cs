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
    public class CobrancaBusiness : ICobrancaBusiness
    {
        private readonly CobrancaData cobrancaData;

        public CobrancaBusiness()
        {
            cobrancaData = new CobrancaData();
        }

        public void Inserir(Cobranca cobranca)
        {
            cobrancaData.Inserir(cobranca);
        }

        public Cobranca BuscarPorId(int cobrancaID)
        {
            return cobrancaData.BuscarPorId(cobrancaID);
        }

        public IEnumerable<Cobranca> BuscarTodos()
        {
            return cobrancaData.BuscarTodos();
        }

        public void Atualizar(Cobranca cobranca)
        {
            cobrancaData.Atualizar(cobranca);
        }

        public void Excluir(int cobrancaID)
        {
            cobrancaData.Excluir(cobrancaID);
        }
    }

}
