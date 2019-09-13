using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatheusMonteiroTeste.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public float Peso { get; set; }
        public decimal Quantidade { get; set; }
        //public virtual Cliente Cliente { get; set; }
        //public ICollection<ClienteProduto> ClienteProduto { get; set; }
    }
}