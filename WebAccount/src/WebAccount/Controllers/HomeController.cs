using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAccount.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Conta()
        {
            ViewData["Message"] = "Cadastro de Clientes";

            return View();
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
