using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
            this.PercentualRendimento = 0.003M;  //precisa do M para atribuir um valor decimal

        }

        public decimal PercentualRendimento { get; private set; }

    }
}
