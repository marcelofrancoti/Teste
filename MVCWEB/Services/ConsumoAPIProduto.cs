using MVCWEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace MVCWEB.Services
{
    public class ConsumoAPIProduto : IConsumo<CadastroProdutoViewModel>
    {
        HttpClient _client = new HttpClient();

        public ConsumoAPIProduto()
        {
            _client.BaseAddress = new Uri("https://localhost:44314/");
        }

        public IEnumerable<CadastroProdutoViewModel> Get()
        {
            HttpResponseMessage result = _client.GetAsync("API/Produto").Result;
            var varJson = result.Content.ReadAsStringAsync();
            IEnumerable<CadastroProdutoViewModel> produtoList = JsonConvert.DeserializeObject<IEnumerable<CadastroProdutoViewModel>>(varJson.Result) as IEnumerable<CadastroProdutoViewModel>;
            return produtoList;
        }

        public CadastroProdutoViewModel GetPorId(int id)
        {
            HttpResponseMessage result = _client.GetAsync("API/Produto/" + id).Result;
            var varJson = result.Content.ReadAsStringAsync();
            CadastroProdutoViewModel produto = JsonConvert.DeserializeObject<CadastroProdutoViewModel>(varJson.Result);
            return produto;
        }

        public void Inserir(CadastroProdutoViewModel produtoP)
        {
            var produtoJson = JsonConvert.SerializeObject(produtoP);
            var buffer = System.Text.Encoding.UTF8.GetBytes(produtoJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PostAsync("API/Produto", byteContent).Result;
        }

        public HttpResponseMessage InserirHttpResponse(CadastroProdutoViewModel produtoP)
        {
            var produtoJson = JsonConvert.SerializeObject(produtoP);
            var buffer = System.Text.Encoding.UTF8.GetBytes(produtoJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PostAsync("API/Produto", byteContent).Result;
            return result;
        }

        public void Alterar(CadastroProdutoViewModel produtoP)
        {
            var produtoJson = JsonConvert.SerializeObject(produtoP);
            var buffer = System.Text.Encoding.UTF8.GetBytes(produtoJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PutAsync("API/Produto/" + produtoP.ProdutoId, byteContent).Result;
            var varJson = result.Content.ReadAsStringAsync();
        }

        public void Excluir(int id)
        {
            HttpResponseMessage result = _client.DeleteAsync("API/Produto/" + id).Result;
        }
    }

}