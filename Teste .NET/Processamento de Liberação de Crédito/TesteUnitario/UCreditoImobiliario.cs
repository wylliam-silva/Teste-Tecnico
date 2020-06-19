using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Modelo.ValueObject;

namespace TesteUnitario
{
    [TestClass]
    public class UCreditoImobiliario
    {
        [TestMethod]
        public void Calcular()
        {
            var valorCredito = 1000000000.00M;
            var quantidadeParcelas = 36;
            var dataPrimeiroVencimento = Convert.ToDateTime("23/08/2020", new CultureInfo("pt-BR"));

            CreditoImobiliario creditoImobiliario = new CreditoImobiliario(new Credito<CreditoImobiliario>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoImobiliario.Taxa });

            CreditoVO creditoVOImobiliario = creditoImobiliario.Calcular();
            
            Console.WriteLine($"Status do Crédito: {creditoVOImobiliario.Status}\nValor Total Com Juros: R$ {creditoVOImobiliario.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOImobiliario.ValorJuros.ToString("#.##")}");
        }
    }
}
