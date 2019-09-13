using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatheusMonteiroTeste.Models.ViewModel
{
    public class ClienteViewModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            this.Id = cliente.Id;
            this.Nome = cliente.Nome;
            this.DataCadastro = cliente.DataCadastro;
            this.CPF_CNPJ = cliente.CPF_CNPJ;
            this.Produtos = cliente.Produtos.ToList();
        }
        public string DataCadastroString
        {
            get
            {
                return DataCadastro.ToString("dd/MM/yyyy");
            }
            /*set
            {
                var data = value.Split('/');
                DataCadastro = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0]));
            }*/
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        //public List<Produto> Produtos { get; set; }
    }
}