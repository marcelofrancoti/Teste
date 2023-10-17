using Entity;
using MVCWEB.Models;
using MVCWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCWEB.Controllers
{
    [Route("{action=listar}")]
    public class CadCobrancaController : Controller
    {
        private readonly ConsumoAPICobranca _consumoAPICobranca;

        public CadCobrancaController()
        {
            _consumoAPICobranca = new ConsumoAPICobranca();
        }

        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            List<CobrancaViewModel> cobrancasViewModel = new List<CobrancaViewModel>();

            var listCobrancas = _consumoAPICobranca.Get();

            if (listCobrancas != null && listCobrancas.Any())
            {
                foreach (var cobranca in listCobrancas)
                {
                    CobrancaViewModel cobrancaViewModel = new CobrancaViewModel
                    {
                        CobrancaId = cobranca.CobrancaId,
                        DataCobranca = cobranca.DataCobranca,
                        ClienteId = cobranca.ClienteId,
                        ProdutoId = cobranca.ProdutoId,
                        NomeCliente = cobranca.NomeCliente,
                        NomeProduto = cobranca.NomeProduto,
                        ValorCobranca = cobranca.ValorCobranca,
                        InformacoesAdicionais = cobranca.InformacoesAdicionais
                    };

                    cobrancasViewModel.Add(cobrancaViewModel);
                }
            }

            return View(cobrancasViewModel);
        }

        public ActionResult Details(int id)
        {
            var cobranca = _consumoAPICobranca.GetPorId(id);

            if (cobranca == null)
            {
                return HttpNotFound();
            }

            CobrancaViewModel cobrancaViewModel = new CobrancaViewModel
            {
                CobrancaId = cobranca.CobrancaId,
                DataCobranca = cobranca.DataCobranca,
                ClienteId = cobranca.ClienteId,
                ProdutoId = cobranca.ProdutoId,
                ValorCobranca = cobranca.ValorCobranca,
                InformacoesAdicionais = cobranca.InformacoesAdicionais
            };

            return View(cobrancaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CobrancaViewModel model)
        {
            try
            {
                _consumoAPICobranca.Inserir(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao criar uma nova cobrança: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var cobranca = _consumoAPICobranca.GetPorId(id);

            if (cobranca == null)
            {
                return HttpNotFound();
            }

            CobrancaViewModel cobrancaViewModel = new CobrancaViewModel
            {
                CobrancaId = cobranca.CobrancaId,
                DataCobranca = cobranca.DataCobranca,
                ClienteId = cobranca.ClienteId,
                ProdutoId = cobranca.ProdutoId,
                ValorCobranca = cobranca.ValorCobranca,
                InformacoesAdicionais = cobranca.InformacoesAdicionais
            };

            return View(cobrancaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CobrancaViewModel model)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao atualizar a cobrança: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            _consumoAPICobranca.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
