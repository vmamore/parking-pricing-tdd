using System;
using Xunit;

namespace Pricing
{
    public class PricingTypeTests
    {
        [Theory]
        [InlineData(60, 5)]
        [InlineData(59, 5)]
        [InlineData(61, 10)]
        [InlineData(120, 10)]
        [InlineData(1440, 120)]
        public void DeveRetornar5DolaresParaCadaHora(int minutosEstacionadas, int valorEsperado)
        {
            var pricingType2 = new PricingType2();

            var valorCalculado = pricingType2.Calcular(minutosEstacionadas);

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Fact]
        public void DeveRetornar1DolarQuandoCarroFicarEstacionadoAte1Hora()
        {
            var horaEstacionada = 1;
            var valorEsperado = 1;

            var pricingType1 = new PricingType1();

            var valorCalculado = pricingType1.Calcular(horaEstacionada);

            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Theory]
        [InlineData(90, 2)]
        [InlineData(120, 2)]
        [InlineData(119, 2)]
        public void DeveRetornar2DolaresQuandoCarroFicarEstacionadoAte2Horas(int minutosEstacionadas, int valorEsperado)
        {
            var pricingType1 = new PricingType1();

            var valorCalculado = pricingType1.Calcular(minutosEstacionadas);

            Assert.Equal(valorEsperado, valorCalculado);
        }
    }

    public class PricingType1
    {
        public int Calcular(int minutosEstacionados)
        {

            if (minutosEstacionados <= 60) return 1;
            else if (minutosEstacionados <= 120) return 2;
            return 0;
        }
    }

    public class PricingType2
    {
        private const int VALOR_HORA = 5;

        public int Calcular(int minutos)
        {
            var resultado = TimeSpan.FromMinutes((double)minutos);

            var horas = resultado.Minutes > 0 ? (int) resultado.TotalHours + 1 : (int)resultado.TotalHours;

            return horas * VALOR_HORA;
        }
    }
}
