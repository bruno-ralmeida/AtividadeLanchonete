using Lanchonete.Produtos;
using System.Collections.Generic;

namespace Lanchonete.Cardapios
{
    interface ICardapio
    {
        void Cadastrar(Produto produto);
        void Listar();

    }
}
