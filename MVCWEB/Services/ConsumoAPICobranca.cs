using Entity;
using MVCWEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVCWEB.Services
{
    public class ConsumoAPICobranca : IConsumo<CobrancaViewModel>
    {
        private HttpClient _client;

        public ConsumoAPICobranca()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44314/"); // Substitua pela URL da sua API.
        }

        public IEnumerable<CobrancaViewModel> Get()
        {
            HttpResponseMessage result = _client.GetAsync("API/Cobranca").Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            var cobrancaList = JsonConvert.DeserializeObject<IEnumerable<CobrancaViewModel>>(responseContent);
            return cobrancaList;
        }

        public CobrancaViewModel GetPorId(int id)
        {
            HttpResponseMessage result = _client.GetAsync($"API/Cobranca/{id}").Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            var cobranca = JsonConvert.DeserializeObject<CobrancaViewModel>(responseContent);
            return cobranca;
        }

        public void Inserir(CobrancaViewModel cobranca)
        {
            var cobrancaJson = JsonConvert.SerializeObject(cobranca);
            var buffer = System.Text.Encoding.UTF8.GetBytes(cobrancaJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PostAsync("API/Cobranca", byteContent).Result;
            result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage InserirHttpResponse(CobrancaViewModel cobranca)
        {
            var cobrancaJson = JsonConvert.SerializeObject(cobranca);
            var buffer = System.Text.Encoding.UTF8.GetBytes(cobrancaJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PostAsync("API/Cobranca", byteContent).Result;
            return result;
        }

        public void Alterar(CobrancaViewModel cobranca)
        {
            var cobrancaJson = JsonConvert.SerializeObject(cobranca);
            var buffer = System.Text.Encoding.UTF8.GetBytes(cobrancaJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage result = _client.PutAsync("API/Cobranca", byteContent).Result;
            result.EnsureSuccessStatusCode();
        }

        public void Excluir(int id)
        {
            HttpResponseMessage result = _client.DeleteAsync($"API/Cobranca/{id}").Result;
            result.EnsureSuccessStatusCode();
        }
    }
}
