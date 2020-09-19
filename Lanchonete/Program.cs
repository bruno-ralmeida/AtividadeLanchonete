using Lanchonete.Cardapios;
using Lanchonete.Pedidos;
using Lanchonete.Refeicao;
using System;

namespace Lanchonete
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CardapioLanche cardapio = new CardapioLanche();
                Pedido pedido = new Pedido(cardapio.Cardapio);

                int opMenu = 0;
                while (opMenu != 5)
                {
                    opMenu = Menu();
                    ExecutaPrograma(cardapio, pedido, opMenu);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
        static void ExecutaPrograma(CardapioLanche cardapioLanche, Pedido pedido, int op)
        {
            
            switch (op)
            {
                case 1:
                    Lanche lanche = RealizarCadastro();
                    cardapioLanche.Cadastrar(lanche);
                    Console.WriteLine("Produto Cadastrado.");
                    break;
                case 2:
                    cardapioLanche.Listar();
                    break;
                case 3:
                    if (cardapioLanche.Cardapio.Count <= 0) Console.WriteLine("Favor cadastrar produtos.");
                    RealizarPedido(cardapioLanche, pedido);
                    Console.WriteLine("Produto adicionado ao carrinho.");
                    break;
                case 4:
                    pedido.Conta();
                    break;
                case 5:
                    Console.WriteLine("Saindo do sistema.");
                    break;
                default:
                    Console.WriteLine("Valor inválido");
                    break;

            }
        }
        static void RealizarPedido(CardapioLanche cardapio, Pedido pedido)
        {
            cardapio.Listar();

            var codPedido = -1;
            Console.WriteLine("Informe o numero do pedido: ");
            int.TryParse(Console.ReadLine(), out codPedido);

            bool produtoAdicionado = pedido.AdicionarAoCarrinho(codPedido - 1);

            Console.WriteLine(new string('=', 100));
            if (produtoAdicionado) Console.WriteLine("Produto adicionado.");
            if (!produtoAdicionado) Console.WriteLine("Erro ao adicionar o produto. Tente novamente.");


        }
        static Lanche RealizarCadastro()
        {
            decimal preco = 0;
            Console.Write("Informe o nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a descriçao do produto: ");
            string descricao = Console.ReadLine();
            Console.Write("Informe o preço do produto: ");
            decimal.TryParse(Console.ReadLine(), out preco);

            return new Lanche(nome, descricao, preco);
        }
        static int Menu()
        {
            int op = 0;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"Selecione uma opção:\n" +
                              $"(1) Cadastro de Lanche.\n" +
                              $"(2) Cardápio\n" +
                              $"(3) Realizar Pedido.\n" +
                              $"(4) Conta.\n" +
                              $"(5) Sair.");

            Console.WriteLine(new string('=', 100));
            int.TryParse(Console.ReadLine(), out op);

            return op;
        }
    }
}


