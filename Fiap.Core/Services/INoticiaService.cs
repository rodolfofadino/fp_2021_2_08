using System.Collections.Generic;
using Fiap.Core.Models;

namespace Fiap.Core.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}