using Fiap.Domain.Models;
using System.Collections.Generic;

namespace Fiap.Application.Interfaces
{
    public interface IRssClient
    {
        public List<Noticia> Load();
    }
}
