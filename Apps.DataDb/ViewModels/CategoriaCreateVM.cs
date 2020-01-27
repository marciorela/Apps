using Apps.DataDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.ViewModels
{
    public class CategoriaCreateVM
    {
        [Required]
        public string Nome { get; set; }
    }

    public static class CategoriaModelExtensions
    {
        public static Categoria ToModel(this CategoriaCreateVM vm, Categoria model)
        {
            model.Nome = vm.Nome;

            return model;
        }

        public static CategoriaCreateVM ToVM(this Categoria model)
        {
            return new CategoriaCreateVM { Nome = model.Nome };
        }
    }
}
