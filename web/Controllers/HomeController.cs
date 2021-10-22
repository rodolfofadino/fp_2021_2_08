using Fiap.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (Produtos.Count() == 0)
            //{
            //    return View("OutraView");
            //}
            //Acessando um DB
            ViewData["nome"] = "<script>alert('teste')</script>";
            ViewBag.Idade = 19;

            var aluno = new Aluno() { Id = 123, Nome = "Everton" };

            return View(aluno);
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno)
        {
            //Salvar no DB

            return View();
        }



        public IActionResult RedirectReturn(string url)
        {
            if (Url.IsLocalUrl(url))
                return LocalRedirect(url);

            return LocalRedirect("/");
        }

    }
}
