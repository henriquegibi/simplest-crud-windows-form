using System;
using System.ComponentModel.DataAnnotations;

namespace simplest_crud_windows_form.Models
{
    class Detail
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
