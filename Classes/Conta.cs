using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Conta
    {
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double credito, double saldo, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("O saldo atual da conta de {0} é R${1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O saldo atual da conta de {0} é R${1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta -> " + this.TipoConta + "\n";
            retorno += "Nome -> " + this.Nome + "\n";
            retorno += $"Saldo -> R${this.Saldo}" + "\n";
            return retorno;
        }
    }
}
