using Lanchonete.Produtos;
using System;


namespace Lanchonete.Refeicao
{
    public class Lanche : Produto
    {
        public override string Nome { get; set; }

        public override string Descricao { get; set; }

        public override decimal Preco { get; set; }
   
        public Lanche(string nome, string descricao, decimal preco)
        {
            if (preco <= 0 || descricao.Length == 0) throw new Exception("Valores inválidos");
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
        
    }
}
