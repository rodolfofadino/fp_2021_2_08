using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Core.ViewModels
{
    public class LoginViewModel
    {
        public string UserName{ get; set; }
        public string Password { get; set; }
        
        [DisplayName("Salvar login")]
        public bool IsPersistent { get; set; }
    }
}
