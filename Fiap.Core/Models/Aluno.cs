using System.ComponentModel.DataAnnotations;

namespace Fiap.Core.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage ="Insira a idade")]
        public int Idade { get; set; }
        public string Profissao{ get; set; }
        public string CEP { get; set; }

        public Status Status { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }


}