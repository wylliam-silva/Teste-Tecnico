using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Modelo.ValueObject;

namespace TesteUnitario
{
    [TestClass]
    public class UCreditoDireto
    {
        [TestMethod]
        public void Calcular()
        {
            var valorCredito = 1000000000.00M;
            var quantidadeParcelas = 36;
            var dataPrimeiroVencimento = Convert.ToDateTime("23/08/2020", new CultureInfo("pt-BR"));

            CreditoDireto creditoDireto = new CreditoDireto(new Credito<CreditoDireto>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoDireto.Taxa });

            CreditoVO creditoVODireto = creditoDireto.Calcular();
            
            Console.WriteLine($"Status do Crédito: {creditoVODireto.Status}\n Valor Total Com Juros: R$ {creditoVODireto.ValorTotalComJuros.ToString("#.##")} \nValor do Juros: R$ {creditoVODireto.ValorJuros.ToString("#.##")}");
        }
    }
}
