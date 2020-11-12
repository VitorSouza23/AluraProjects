using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraindoMetodos
{
    class Relatorio
    {
        void Imprimir()
        {
            Pedido pedido = CriarPedido();
            decimal total = ImprimirIncio(pedido);
            ImprimirFim(pedido, total);
        }

        private static Pedido CriarPedido()
        {
            var pedido = new Pedido("José da Silva");
            pedido.AddItem("Dentozap", 2, 10m, 0m, 3m);
            pedido.AddItem("Voldax", 3, 10m, 0m, 3m);
            pedido.AddItem("Tranlab", 7, 10m, 0m, 3m);
            return pedido;
        }

        private static void ImprimirFim(Pedido pedido, decimal total)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Resumo************");
            Console.WriteLine("*****************************");
            Console.WriteLine("nome: " + pedido.Cliente);
            Console.WriteLine("valor: " + total);
        }

        private static decimal ImprimirIncio(Pedido pedido)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Itens ************");
            Console.WriteLine("*****************************");
            decimal total = 0.0m;
            foreach (var item in pedido.Itens)
            {
                decimal valorItem = item.Quantidade * item.PrecoBase;
                Console.WriteLine($"{item.Desconto}: {item.Quantidade} unidades, R$ {valorItem}");
                total = total + valorItem;
            }

            return total;
        }
    }
}
