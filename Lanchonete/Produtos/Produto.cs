using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Produtos
{
    public abstract class Produto
    {
        public abstract string Nome { get; set; }

        public abstract string Descricao { get; set; }

        public abstract decimal Preco { get; set; }

        public override string ToString()
        {
            return $"Produto: {Nome,-20} || Descrição: {Descricao,-30} || Valor: {Preco,-10:C}";
        }
    }
}
