using System;
using System.Globalization;
using DIO_Bank.Enum;

namespace DIO_Bank.models
{
    public class Conta
    {
        public Conta(string nome, double saldo, double credito, TipoConta tipoConta )
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
        }        
        
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private TipoConta TipoConta {get; set;}
        

        public bool Sacar(double valorSaque){

            if((this.Saldo - valorSaque) < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            //Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            //outra forma de interpolação de strings
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

            return true;
        }


        public void Depositar(double valorDepositado){
            this.Saldo += valorDepositado;
            
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);

            
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"TipoConta {this.TipoConta} |";
            retorno += $" Nome {this.Nome} |";
            retorno += $" Saldo {this.Saldo} |";
            retorno += $" Crédito {this.Credito} |";
            return retorno;
        }

    }
}