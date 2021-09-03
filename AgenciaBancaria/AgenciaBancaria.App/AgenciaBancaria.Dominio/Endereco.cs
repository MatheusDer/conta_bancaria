﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Endereco  //Fazendo essa classe pq o endereço engloba varias informações
    {
        public Endereco(string logradouro, string cep, string cidade, string estado)
        {
            this.Logradouro = logradouro.ValidaStringVazia();
            this.CEP = cep.ValidaStringVazia();
            this.Cidade = cidade.ValidaStringVazia();
            this.Estado = estado.ValidaStringVazia();
        }
        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
