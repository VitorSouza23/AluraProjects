using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraindoMetodos
{
    class Pedido
    { 

        public Pedido(string cliente)
        {
            Cliente = cliente;
            Itens = new List<Item>();
        }

        public Pedido()
        {
            Itens = new List<Item>();
        }

        public string Cliente { get; set; }

        public List<Item> Itens { get; set; }

        public void AddItem(string nome, int quantidade, decimal precoBase, decimal desconto, decimal acrescimo)
        {
            Itens.Add(new Item
            {
                Nome = nome,
                Acrescimo = acrescimo,
                Desconto = desconto,
                PrecoBase = precoBase,
                Quantidade = quantidade,
            });
        }
    }
}
