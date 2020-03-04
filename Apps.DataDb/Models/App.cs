using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Models
{
    public class App : Entity
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Versão")]
        public string Versao { get; set; }

        public string Plataforma { get; set; }

        [Required]
        public string PathExe { get; set; }

        public string PathImg { get; set; }

        public string ParamSilentInstall { get; set; }

        public string Serials { get; set; }

        [Required]
        public virtual Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }

        public override string ToString()
        {
            return $"{Nome} ({Versao})";
        }
    }
}
