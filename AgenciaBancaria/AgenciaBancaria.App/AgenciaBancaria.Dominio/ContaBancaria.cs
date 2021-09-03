using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            this.Cliente = cliente ?? throw new Exception("Cliente deve ser informado");

            Random random = new Random();
            NumeroConta = random.Next(1000, 9999);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;  //assim que eh criada ela ja faz isso
            
        }

        public void AbrirConta(string senha)
        {
            SetSenha(senha);

            this.Situacao = SituacaoConta.Aberta;
            this.DataAbertura = DateTime.Now;
        }

        public void FecharConta(string senha)
        {
            if (senha != this.Senha)
                throw new Exception("Senha invalida");

            this.Situacao = SituacaoConta.Encerrada;
            this.DataEncerramento = DateTime.Now;

        }

        public void AlterarSenha(string senhaAntiga, string senhaNova)
        {
            if (senhaAntiga != this.Senha)
                throw new Exception("Senha invalida");


            SetSenha(senhaNova);
        }

        private void SetSenha(string senha)
        {
            //Minimo de 8 caracteres, pelo menos uma letra de a-z e pelo menos um numero de 0 a 9
            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha invalida");
            }

            this.Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (senha != this.Senha)
                throw new Exception("Senha invalida.");

            if (this.Saldo < valor)
                throw new Exception("Saldo insuficiente");

            this.Saldo -= valor;
        }

        public void Depositar(decimal valor, string senha)
        {
            if (senha != this.Senha)
                throw new Exception("Senha invalida.");

            this.Saldo += valor;
        }

        public int NumeroConta { get; init; }  //init so pode ser setado no construtor
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }  //? diz que permite ser nulo(por padrao nao permitiria)
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }
    }
}
