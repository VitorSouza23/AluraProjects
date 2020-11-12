using Alura.LeilaoOnlien.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoTeerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDoLeilaoComPeloMenosUmLance(double valoresperado, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van gog");
            var flano = new Interessada("Flano", leilao);
           
            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(flano, valor);
            }

            //Act
            leilao.TerminarPregao();

            //Assert
            double expected = valoresperado;
            double result = leilao.Ganhador.Valor;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLance()
        {
            //Arrange
            var leilao = new Leilao("Van gog");
            
            //Act
            leilao.TerminarPregao();

            //Assert
            double expected = 0;
            double result = leilao.Ganhador.Valor;

            Assert.Equal(expected, result);
        }
    }
}
