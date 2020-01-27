using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Models
{
    public class Categoria : Entity
    {
        [StringLength(100)]
        public string Nome { get; set; }

//        public virtual App Aplicativo { get; set; }
    }
}
