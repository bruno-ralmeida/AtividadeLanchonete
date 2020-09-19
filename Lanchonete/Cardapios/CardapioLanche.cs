using Lanchonete.Produtos;
using Lanchonete.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lanchonete.Cardapios
{
    class CardapioLanche : ICardapio
    {
        public List<Produto> Cardapio { get; }
        public CardapioLanche()
        {
            Cardapio = new List<Produto> { };
        }
        public void Cadastrar(Produto produto)
        {
            Lanche lanche = produto as Lanche;
            if (Cardapio.Count > 10 && Cardapio != null) throw new Exception("Você atingiu o limite máximo para o cadastro de Lanches.");

            if (lanche is null) throw new Exception("Erro ao cadatrar o lanche.");

            Cardapio.Add(lanche);

        }
        public void Listar()
        {
            if (Cardapio.Count < 0) throw new Exception("Cardapio vazio, favor cadastrar novos produtos.");

            var count = 1;

            foreach (var lanche in Cardapio)
            {
                Console.WriteLine($"Opção: {count} - {lanche.ToString()}");
                count++;
            }

        }
    }
}
