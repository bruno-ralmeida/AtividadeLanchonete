using System;
using System.Collections.Generic;
using Lanchonete.Produtos;

namespace Lanchonete.Pedidos
{
    public class Pedido
    {
        private static Dictionary<Produto, int> _pedidos = new Dictionary<Produto, int>();
        private List<Produto> _cardapio;

        public Pedido(List<Produto> cardapio)
        {
            _cardapio = cardapio;
        }

        public bool AdicionarAoCarrinho(int i)
        {
            if (i < 0 || i > _cardapio.Count) return false;

            var prodNoCarrinho = _pedidos.ContainsKey(_cardapio[i]);
            
            if(!prodNoCarrinho) _pedidos.Add(_cardapio[i], 1);
            if (prodNoCarrinho) _pedidos[_cardapio[i]] += 1;
            
            return true;
        }
        public void Conta()
        {
            Console.WriteLine("\n\nPEDIDOS\n\n", -100);

            foreach (KeyValuePair<Produto, int> pedido in _pedidos)
            {
                Console.WriteLine($"Pedido: {pedido.Key.Nome,-20} || Quantidade: {pedido.Value,-20} || Total: {pedido.Key.Preco * pedido.Value,-10:C}");
            }

            Total();
        }
        private decimal Taxa(decimal total, int porcentagem)
        {
            return (total * porcentagem) / 100;
        }
        private void Total()
        {
            decimal total = 0;
            foreach (KeyValuePair<Produto, int> pedido in _pedidos)
            {
                total += pedido.Key.Preco * pedido.Value;
            }
            decimal taxa = Taxa(total, 7);

            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\n\nCONTA\n\n", -100);
            Console.WriteLine($"Total: {total:C}");
            Console.WriteLine($"Taxa de Serviço(7%): {taxa:C}");
            Console.WriteLine($"Total a pagar: {total + taxa:C}");
        }
    }
}
