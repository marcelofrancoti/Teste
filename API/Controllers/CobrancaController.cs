using Business;
using Business.Interfaces;
using Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class CobrancaController : ApiController
    {
        private readonly ICobrancaBusiness _cobrancaBusiness = new CobrancaBusiness();

        // GET: api/Cobranca
        public IEnumerable<Cobranca> Get()
        {
            return _cobrancaBusiness.BuscarTodos();
        }

        // GET: api/Cobranca/5
        public Cobranca Get(int id)
        {
            return _cobrancaBusiness.BuscarPorId(id);
        }

        // POST: api/Cobranca
        public void Post([FromBody] Cobranca cobranca)
        {
            _cobrancaBusiness.Inserir(cobranca);
        }

        // PUT: api/Cobranca/5
        public void Put(int id, [FromBody] Cobranca cobranca)
        {
            cobranca.CobrancaID = id;
            _cobrancaBusiness.Atualizar(cobranca);
        }

        // DELETE: api/Cobranca/5
        public void Delete(int id)
        {
            _cobrancaBusiness.Excluir(id);
        }
    }
}
