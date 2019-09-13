using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatheusMonteiroTeste.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime DataCadastro {get;set;}
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}