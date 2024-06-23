using System;
using System.Collections.Generic;

namespace CompraPassagem
{
    // Classe Passagem
    public class Passagem
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }

        public Passagem(int id, string origem, string destino, DateTime data, double preco)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Data = data;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Passagem ID: {Id}, Origem: {Origem}, Destino: {Destino}, Data: {Data.ToShortDateString()}, Preço: {Preco:C}";
        }
    }

    // Classe Cliente
    public class Cliente
    {
        public string Nome { get; set; }
        public List<Passagem> PassagensCompradas { get; set; }

        public Cliente(string nome)
        {
            Nome = nome;
            PassagensCompradas = new List<Passagem>();
        }

        public void ComprarPassagem(Passagem passagem)
        {
            PassagensCompradas.Add(passagem);
            Console.WriteLine($"{Nome} comprou a passagem: {passagem}");
        }

        public void ListarPassagens()
        {
            Console.WriteLine($"Passagens compradas por {Nome}:");
            foreach (var passagem in PassagensCompradas)
            {
                Console.WriteLine(passagem);
            }
        }
    }

    // Classe SistemaCompraPassagem
    public class SistemaCompraPassagem
    {
        private List<Passagem> passagens;
        private List<Cliente> clientes;

        public SistemaCompraPassagem()
        {
            passagens = new List<Passagem>
            {
                new Passagem(1, "São Paulo", "Rio de Janeiro", new DateTime(2024, 7, 10), 300.00),
                new Passagem(2, "Rio de Janeiro", "Salvador", new DateTime(2024, 7, 12), 400.00),
                new Passagem(3, "Belo Horizonte", "Brasília", new DateTime(2024, 7, 15), 350.00),
            };

            clientes = new List<Cliente>();
        }

        public void MostrarMenu()
        {
            int opcao = -1;
            while (opcao != 0)
            {
                Console.WriteLine("1. Listar Passagens");
                Console.WriteLine("2. Comprar Passagem");
                Console.WriteLine("3. Listar Minhas Passagens");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            ListarPassagens();
                            break;
                        case 2:
                            ComprarPassagem();
                            break;
                        case 3:
                            ListarMinhasPassagens();
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
        }

        private void ListarPassagens()
        {
            Console.WriteLine("Passagens disponíveis:");
            foreach (var passagem in passagens)
            {
                Console.WriteLine(passagem);
            }
        }

        private void ComprarPassagem()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            if (cliente == null)
            {
                cliente = new Cliente(nome);
                clientes.Add(cliente);
            }

            Console.Write("Digite o ID da passagem que deseja comprar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Passagem passagem = passagens.Find(p => p.Id == id);

                if (passagem != null)
                {
                    cliente.ComprarPassagem(passagem);
                }
                else
                {
                    Console.WriteLine("Passagem não encontrada!");
                }
            }
            else
            {
                Console.WriteLine("Por favor, insira um número válido.");
            }
        }

        private void ListarMinhasPassagens()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            if (cliente != null)
            {
                cliente.ListarPassagens();
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
        }
    }

    // Classe Program
    class Program
    {
        static void Main(string[] args)
        {
            SistemaCompraPassagem sistema = new SistemaCompraPassagem();
            sistema.MostrarMenu();
        }
    }
}
