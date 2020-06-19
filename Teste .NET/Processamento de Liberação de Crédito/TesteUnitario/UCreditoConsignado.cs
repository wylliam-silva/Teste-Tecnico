using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Modelo.ValueObject;

namespace TesteUnitario
{
    [TestClass]
    public class UCreditoConsignado
    {
        [TestMethod]
        public void Calcular()
        {
            var valorCredito = 1000000000.00M;
            var quantidadeParcelas = 36;
            var dataPrimeiroVencimento = Convert.ToDateTime("23/08/2020", new CultureInfo("pt-BR"));

            CreditoConsignado creditoConsignado = new CreditoConsignado(new Credito<CreditoConsignado>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoConsignado.Taxa });

            CreditoVO creditoVOConsignado = creditoConsignado.Calcular();
            
            Console.WriteLine($"Status do Crédito: {creditoVOConsignado.Status}\nValor Total Com Juros: R$ {creditoVOConsignado.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOConsignado.ValorJuros.ToString("#.##")}");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
