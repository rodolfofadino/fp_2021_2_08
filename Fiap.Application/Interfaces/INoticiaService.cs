using System.Collections.Generic;
using Fiap.Domain.Models;

namespace Fiap.Application.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}