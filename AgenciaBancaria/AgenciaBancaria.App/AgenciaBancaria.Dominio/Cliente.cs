using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {

        public Cliente(string nome, string cpf, string rg, Endereco endereco)
        {
            this.Nome = nome.ValidaStringVazia();  //recebe o nome como parametro
            this.CPF = cpf.ValidaStringVazia();
            this.RG = rg.ValidaStringVazia();
            this.Endereco = endereco ?? throw new Exception("Propriedade precisa ser preenchida");  //se for nulo, entao...
            
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }

        public Endereco Endereco { get; private set; }

    }
}
