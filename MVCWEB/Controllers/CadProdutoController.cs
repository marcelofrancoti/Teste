using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MVCWEB.Models;
using MVCWEB.Services;
using Newtonsoft.Json;

[RoutePrefix("CadProduto")]
public class CadProdutoController : Controller
{
    private readonly ConsumoAPIProduto _consumoAPIProduto;

    public CadProdutoController()
    {
        _consumoAPIProduto = new ConsumoAPIProduto();
    }

    // GET: CadProduto
    [Route("Listar")]
    public ActionResult Index()
    {
        List<CadastroProdutoViewModel> produtos = _consumoAPIProduto.Get().ToList();
        return View(produtos);
    }

    // GET: CadProduto/Details/5
    public ActionResult Details(int id)
    {
        CadastroProdutoViewModel produto = _consumoAPIProduto.GetPorId(id);
        if (produto == null)
        {
            return HttpNotFound();
        }
        return View(produto);
    }

    // GET: CadProduto/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CadProduto/Create
    [HttpPost]
    public ActionResult Create(CadastroProdutoViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _consumoAPIProduto.Inserir(model);
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao criar um novo produto: " + ex.Message);
        }

        return View(model);
    }

    // GET: CadProduto/Edit/5
    public ActionResult Edit(int id)
    {
        CadastroProdutoViewModel produto = _consumoAPIProduto.GetPorId(id);
        if (produto == null)
        {
            return HttpNotFound();
        }
        return View(produto);
    }

    // POST: CadProduto/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, CadastroProdutoViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _consumoAPIProduto.Alterar(model);
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao atualizar o produto: " + ex.Message);
        }

        return View(model);
    }

    // GET: CadProduto/Delete/5
    public ActionResult Delete(int id)
    {
        CadastroProdutoViewModel produto = _consumoAPIProduto.GetPorId(id);
        if (produto == null)
        {
            return HttpNotFound();
        }
        return View(produto);
    }

    // POST: CadProduto/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            _consumoAPIProduto.Excluir(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao excluir o produto: " + ex.Message);
        }

        return View();
    }
}
