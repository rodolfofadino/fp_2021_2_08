using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Domain.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo{ get; set; }
        public string Link { get; set; }
        public string Imagem { get; set; }
    }
}
