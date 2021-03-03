using System;
using System.Collections.Generic;
using DIO_Bank.Enum;
using DIO_Bank.models;

namespace DIO_Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }   
                opcaoUsuario = ObterOpcaoUsuario();
            }




            //Conta minhaConta = new Conta("Alexandre", 0, 0, TipoConta.PessoaFisica);
            //Console.WriteLine(minhaConta.ToString());

           Console.WriteLine("Obrigado por utilizar nossos serviços!");
           Console.ReadLine();

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valortransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valortransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            // for (int i = 0; i < listContas.Count; i++){
            //     Conta conta = listContas[i];
            //     Console.Write($"#{i} - ");
            //     Console.WriteLine(conta);
            // }

            int x = 0;
            foreach (var dadosConta in listContas)
            { 

                Conta conta = dadosConta;
                Console.Write($"#{x} - ");
                Console.WriteLine(conta);
                x +=1;
            }



        }

        private static void InserirConta()
        {
           Console.WriteLine("Inserir nova conta");

           Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
           int entradaTipoConta = int.Parse(Console.ReadLine());
           
           Console.Write("Digite o Nome do Cliente: ");
           string entradaNome = Console.ReadLine();
           
           Console.Write("Digite o saldo inicial: ");
           double entradaSaldo = int.Parse(Console.ReadLine());
           
           Console.Write("Digite o crédito: ");
           double entradaCredito = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();

            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta" );
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }



    }





}
