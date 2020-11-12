namespace Alura.LeilaoOnlien.Core
{
    public class Lance
    {
        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
        }

        public Interessada Cliente { get; }
        public double Valor { get; }
    }
}