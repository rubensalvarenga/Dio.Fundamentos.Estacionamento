using System;
using System.Collections.Generic;
using Fundamentos.Estacionamento.Models;

namespace Fundamentos.Estacionamento
{
    public class Program
    {
        public static List<Carro> carros = new List<Carro>(); // Declaração da lista de carros
        public static decimal entradaHora;
        public static decimal entradaInicial;
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Controle de Estacionamento");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("==========================");
            Console.WriteLine("");
            Console.WriteLine("Vamos começar nosso 1.Desafio na DIO");
            Console.WriteLine("");
            Console.WriteLine("Informe o valor inicial:");
            entradaInicial = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Informe o valor da Hora usada:");
            entradaHora = Convert.ToDecimal(Console.ReadLine());

            Exibir(); 

            

        }

        public static void Exibir()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("MENU DE ENTRADA DE VEÍCULO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.WriteLine("===========================");
            Console.WriteLine("");
            Console.WriteLine("0 - SAIR DO SISTEMA");
            Console.WriteLine("");
            Console.WriteLine("1 - ENTRADA DO VEICULO");
            Console.WriteLine("");
            Console.WriteLine("2 - EXCLUIR VEICULO");
            Console.WriteLine("");
            Console.WriteLine("3 - LISTA DE VEICULO NO ESTACIONAMENTO");
            Console.WriteLine("");
            Console.WriteLine("4 - LISTA DE VEICULO QUE SAIRAM");
            Console.WriteLine("");
            Console.WriteLine("5 - DAR SAÍDA DO VEICULO");
            Console.WriteLine("");
            Console.WriteLine("6 - FECHAMENTO DO CAIXA");

            var opcao = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch (opcao)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.Clear();
                    Carro carro = new Carro();
                    carro.Adiciona(carros);
                    break;
                case 2:
                    Console.Clear();
                    Carro carro5 = new Carro();
                    carro5.Excluir(carros);
                    break;
                case 3: 
                    Console.Clear();
                    Carro carro1 = new Carro();
                    carro1.Lista(carros);
                    break;
                case 4:
                    Console.Clear();
                    Carro carro2 = new Carro();
                    carro2.ListaPagos(carros);
                    break;
                case 5:
                    Console.Clear();
                    Carro carro3 = new Carro();
                    carro3.Saida(carros, entradaHora, entradaInicial);
                    break;
                case 6: 
                    Console.Clear();
                    Carro carro4 = new Carro();
                    carro4.Caixa(carros);
                    break;

            }
        }
    }
}

