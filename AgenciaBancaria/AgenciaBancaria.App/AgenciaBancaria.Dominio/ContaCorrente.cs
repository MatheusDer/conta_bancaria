using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Cliente cliente, decimal limite) : base(cliente)
        {
            this.ValorTaxa = 0.05M;
            this.Limite = limite;
        }

        public override void Sacar(decimal valor, string senha)
        {
            if (senha != this.Senha)
                throw new Exception("Senha invalida.");

            if (this.Saldo + this.Limite < valor)
                throw new Exception("Saldo insuficiente");

            this.Saldo -= valor;
        }

        public decimal ValorTaxa { get; private set; }
        public decimal Limite { get; private set; }

    }
}
