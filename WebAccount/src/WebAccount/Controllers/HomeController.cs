using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using WebAccountAPI.Models;

namespace WebAccount.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Conexão Web Api
        /// </summary>
        private HttpClient webApi = getWebApi();

        /// <summary>
        /// Retorna a conexão com o Web API
        /// </summary>
        /// <returns></returns>
        private static HttpClient getWebApi()
        {
            HttpClient webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:56776");
            webApi.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return webApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        private IEnumerable<Account> getAll()
        { //chamando a api pela url            
            System.Net.Http.HttpResponseMessage response = webApi.GetAsync("api/account").Result;

            Uri usuarioUri = null;

            //se retornar com sucesso busca os dados            
            if (response.IsSuccessStatusCode)
            {          //pegando o cabeçalho                
                usuarioUri = response.Headers.Location;

                string stringData = response.Content.
                ReadAsStringAsync().Result;
                IEnumerable<Account> data = JsonConvert.
            DeserializeObject<IEnumerable<Account>>(stringData);

                return data;

                //Pegando os dados do Rest e armazenando na variável usuários
                //var accounts = response.Content.ReadAsStringAsync().ReadAsAsync<IEnumerable<Account>>().Result;
                //response.Content.
            }

            return null;
        }
        public IActionResult Conta()
        {
            ViewData["Message"] = "Cadastro de Clientes";

            return View(getAll());
        }

        public IActionResult Compra()
        {
            ViewData["Message"] = "Cadastro de Compras";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
