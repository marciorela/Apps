using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Models
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }

        [DisplayName("Data Cadastro")]
        [Required]
        public DateTime DataCadastro { get; set; }


    }
}
