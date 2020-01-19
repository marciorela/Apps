using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Models
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }


    }
}
