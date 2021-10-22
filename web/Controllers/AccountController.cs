using Fiap.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fiap.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                //return Redirect("/");
                return RedirectToAction("Index", "Alunos");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            //simulando acesso ao DB
            if (login.UserName == "rodolfo" && login.Password == "123")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.UserName));
                claims.Add(new Claim(ClaimTypes.Role,"admins"));

                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("fiap", principal, new AuthenticationProperties() {  IsPersistent = login.IsPersistent });

                return RedirectToAction("Index", "Alunos");
            }

            return View(login);
        }


        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
