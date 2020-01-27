using Apps.DataDb.Models;
using Apps.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.ViewModels
{
    public class UsuarioCadVM
    {

        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe seu e-mail")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        [DisplayName("Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        [Required(ErrorMessage = "Informe a confirmação da senha")]
        public string RedSenha { get; set; }

    }

    public static class UsuarioModelExtensions
    {
        public static UsuarioCadVM ToVM(this Usuario data)
        {
            return new UsuarioCadVM
            {
                Nome = data.Nome,
                Email = data.Mail,
                Senha = ""
            };
        }

        public static Usuario ToModel(this UsuarioCadVM data, Usuario usuario)
        {
            usuario.Nome = data.Nome;
            usuario.Mail = data.Email;
            usuario.Senha = data.Senha.Encrypt();

            return usuario;
        }
    }
}
