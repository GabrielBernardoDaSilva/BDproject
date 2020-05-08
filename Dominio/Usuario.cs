using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preencha o nome do ususario")]
        public string nome { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Preencha o cargo do ususario")]
        public string cargo { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Preencha a data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yy}")]
        public DateTime data { get; set; }

    }
}
