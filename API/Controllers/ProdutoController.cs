using Business;
using Business.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoBusiness _produtoBusiness = new ProdutoBusiness();

        // GET: api/Produto
        public IEnumerable<Produto> Get()
        {
            return _produtoBusiness.BuscarTodos();
        }

        // GET: api/Produto/5
        public Produto Get(int id)
        {
            return _produtoBusiness.BuscarPorId(id);
        }

        // POST: api/Produto
        public IHttpActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("O produto não pode ser nulo.");
            }

            _produtoBusiness.Inserir(produto);

            return Created(Request.RequestUri + produto.ProdutoId.ToString(), produto);
        }

        // PUT: api/Produto/5
        public IHttpActionResult Put(int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("O produto não pode ser nulo.");
            }

            var produtoExistente = _produtoBusiness.BuscarPorId(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            produto.ProdutoId = id;
            _produtoBusiness.Atualizar(produto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Produto/5
        public IHttpActionResult Delete(int id)
        {
            var produtoExistente = _produtoBusiness.BuscarPorId(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            _produtoBusiness.Excluir(id);

            return Ok();
        }
    }

}