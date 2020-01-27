using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.ViewModels
{
    public class UsuarioSignInVM
    {

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe seu e-mail")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        [DisplayName("Manter conectado")]
        public bool Lembrar { get; set; }

    }
}
