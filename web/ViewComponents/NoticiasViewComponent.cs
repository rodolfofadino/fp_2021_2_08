using Fiap.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var view = "noticias";
            if (noticiasUrgentes)
            {
                view = "noticiasurgentes";
            }
            var noticias = GetNoticias(total);

            return View(view, noticias);
        }

        private IEnumerable<Noticia> GetNoticias(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i + 1, Titulo = $"Noticia {i}", Link = $"http://{i}" };
            }
        }
    }
}
