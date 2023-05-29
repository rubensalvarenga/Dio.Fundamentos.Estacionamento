using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentos.Estacionamento;

namespace Fundamentos.Estacionamento.Models
{
    public class Carro
    {
        public string placa = "";
        public string dataChegada = "";
        public string dataSaida = "";
        public string horaChegada = "";
        public string horaSaida = "";
        public decimal valorPago = 0;
        public bool fechado = false;

        public void Adiciona(List<Carro> carros)
        {
            Console.WriteLine("Incluir os dados do veiculo");
            Console.WriteLine("");
            Console.WriteLine("Placa : Formato XYZ1234");
            string pl = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Data Chegada : Formato DD/MM");
            string dc = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hora da Chegada : Formato HH:MM");
            string hc = Console.ReadLine();
            Console.WriteLine("");

            Carro novoCarro = new Carro(); // Cria um novo objeto Carro
            novoCarro.placa = pl; // Preenche as propriedades do novo carro
            novoCarro.dataChegada = dc;
            novoCarro.horaChegada = hc;

            carros.Add(novoCarro); // Adiciona o novo carro à lista de carros

            Console.WriteLine("Pressione qq tecla para voltar ao Menu");
            Console.ReadLine();
            Program.Exibir();

        }

        public void Lista(List<Carro> carros)
        {
            Console.WriteLine("VEICULOS QUE ESTÃO NO PATIO");
            Console.WriteLine("===========================");
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in carros)
            {
                if (!item.fechado)
                {
                    Console.WriteLine(item.placa);
                    Console.WriteLine(item.dataChegada);
                    Console.WriteLine(item.horaChegada);
                }
            }

            Console.WriteLine("Pressione qq tecla para voltar ao Menu");
            Console.ReadLine();
            Program.Exibir();
        }


        public void ListaPagos(List<Carro> carros)
        {
            Console.WriteLine("VEICULOS ** PAGOS **");
            Console.WriteLine("====================");
            Console.WriteLine("");
            Console.WriteLine("");

            int conta = 0;

            foreach (var item in carros)
            {

                if (item.fechado)
                {
                    conta++;
                    Console.WriteLine(item.placa);
                    Console.WriteLine(item.dataChegada);
                    Console.WriteLine(item.horaChegada);
                    Console.WriteLine(item.dataSaida);
                    Console.WriteLine(item.horaSaida);

                    Console.WriteLine("==================");


                }
            }
            Console.WriteLine($"Total de carros que já pagaram {conta}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressione qq tecla para voltar ao Menu");
            Console.ReadLine();
            Program.Exibir();
        }


        public void Saida(List<Carro> carros, decimal valorHora, decimal valorEntrada)
        {
            Console.WriteLine("DIGITE A PLACA PARA SAIDA");
            Console.WriteLine("=========================");
            Console.WriteLine("");
            string placa = Console.ReadLine();
            Console.WriteLine("");

            // Criar um objeto calculo para fazer a pesquisa
            Carro pesquisaCarro = carros.FirstOrDefault(c => c.placa == placa);

            if (pesquisaCarro == null)
            {
                Console.WriteLine("Carro não encontrado na lista.");
                Console.WriteLine("");
                Console.WriteLine("Pressione qq tecla para voltar ao Menu");
                Console.ReadLine();
                Program.Exibir();
            }
            else
            {
                Console.WriteLine($"O carro com a placa {pesquisaCarro.placa} foi encontrado.");
                Console.WriteLine("");
                Console.WriteLine("Data de saída:");
                string dataSaida = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Hora de saída:");
                string horaSaida = Console.ReadLine();
                Console.WriteLine("");

                pesquisaCarro.dataSaida = dataSaida;
                pesquisaCarro.horaSaida = horaSaida;

                decimal horas = calculoHoras(pesquisaCarro.horaChegada, pesquisaCarro.horaSaida);
                Console.WriteLine($"Horas calculadas: {horas}");

                pesquisaCarro.valorPago = (horas * valorHora) + valorEntrada;
                pesquisaCarro.fechado = true;
                Console.WriteLine("=================================");
                Console.WriteLine("");
                Console.WriteLine(pesquisaCarro.placa);
                Console.WriteLine(pesquisaCarro.dataChegada);
                Console.WriteLine(pesquisaCarro.horaChegada);
                Console.WriteLine(pesquisaCarro.dataSaida);
                Console.WriteLine(pesquisaCarro.horaSaida);
                Console.WriteLine(pesquisaCarro.valorPago);
                Console.WriteLine(pesquisaCarro.fechado);
                Console.WriteLine("");
                Console.WriteLine("=================================");
                Console.WriteLine("");
                Console.WriteLine("Pressione qq tecla para voltar ao Menu");
                Console.ReadLine();
                Program.Exibir();


            }
        }

        public decimal calculoHoras(string data1, string data2)
        {


            decimal valor2 = decimal.Parse(data2.Substring(0, 2));
            decimal valor1 = decimal.Parse(data1.Substring(0, 2));

            decimal horas = valor2 - valor1;

            return horas;
        }

        public void Caixa(List<Carro> carros)
        {
            Console.WriteLine("VEICULOS ** CAIXA **");
            Console.WriteLine("====================");
            Console.WriteLine("");
            Console.WriteLine("");
            decimal total = 0;

            foreach (var item in carros)
            {
                if (item.fechado)
                {
                    Console.WriteLine(item.placa);
                    Console.WriteLine(item.valorPago.ToString("F2"));
                    Console.WriteLine("==================");
                    total = total + item.valorPago;

                }
            }
            Console.WriteLine("TOTAL : " + total.ToString("F2"));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressione qq tecla para voltar ao Menu");
            Console.ReadLine();
            Program.Exibir();
        }

        public void Excluir(List<Carro> carros)
        {
            Console.WriteLine("DIGITE A PLACA PARA SAIDA");
            Console.WriteLine("=========================");
            Console.WriteLine("");
            string placa = Console.ReadLine();
            Console.WriteLine("");

            // Criar um objeto calculo para fazer a pesquisa
            Carro pesquisaCarro = carros.FirstOrDefault(c => c.placa == placa);

            if (pesquisaCarro == null)
            {
                Console.WriteLine("Carro não encontrado na lista.");
                Console.WriteLine("");
                Console.WriteLine("Pressione qq tecla para voltar ao Menu");
                Console.ReadLine();
                Program.Exibir();
            }
            else
            {
                Console.WriteLine($"O carro com a placa {pesquisaCarro.placa} foi encontrado.");
                Console.WriteLine("");
                Console.WriteLine("Excluindo a placa do sistema ...");
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Excluido ...");
                Console.BackgroundColor = ConsoleColor.Black;

                carros.Remove(pesquisaCarro);

                Console.WriteLine("");
                Console.WriteLine("Pressione qq tecla para voltar ao Menu");
                Console.ReadLine();
                Program.Exibir();

            }

        }
    }

}
