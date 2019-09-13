using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatheusMonteiroTeste.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public float Peso { get; set; }
        public decimal Quantidade { get; set; }
    }
}