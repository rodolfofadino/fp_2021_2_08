using Fiap.Domain.Models;
using Fiap.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        private INoticiaService _service;

        public NoticiasViewComponent(INoticiaService service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var view = "noticias";
            if (noticiasUrgentes)
            {
                view = "noticiasurgentes";
            }

            return View(view, _service.Load(total));
        }

        
    }
}
