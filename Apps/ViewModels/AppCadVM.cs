using Apps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ViewModels
{
    public class AppCadVM
    {

        [Required(ErrorMessage = "Nome deve ser informado")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }

        [DisplayName("Versão")]
        public string Versao { get; set; }

        public string Plataforma { get; set; }

        [DisplayName("Path Executável")]
        [Required(ErrorMessage = "Informe o caminho do executável principal da aplicação")]
        public string PathExe { get; set; }

//        public string PathImg { get; set; }

        [DisplayName("Parâmetros para instalação silenciosa")]
        public string ParamSilentInstall { get; set; }

    }

    public static class AppModelExtensions
    {
        public static AppCadVM ToVM(this App data)
        {
            return new AppCadVM
            {
                Nome = data.Nome,
                Descricao = data.Descricao,
                ParamSilentInstall = data.ParamSilentInstall,
                PathExe = data.PathExe,
                Plataforma = data.Plataforma,
                Versao = data.Versao
            };
        }

        public static App ToModel(this AppCadVM data, App model)
        {
            model.Nome = data.Nome;
            model.Descricao = data.Descricao;
            model.ParamSilentInstall = data.ParamSilentInstall;
            model.PathExe = data.PathExe;
            model.Plataforma = data.Plataforma;
            model.Versao = data.Versao;

            return model;
        }
    }
}
