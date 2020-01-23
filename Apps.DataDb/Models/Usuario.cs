using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Models
{
    public class Usuario : Entity
    {
        [Required]
        [StringLength(100)]
        public string Mail { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }


    }
}
