using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Modelo.ValueObject;

namespace TesteUnitario
{
    [TestClass]
    public class UCreditoPessoaFisica
    {
        [TestMethod]
        public void Calcular()
        {
            var valorCredito = 1000000000.00M;
            var quantidadeParcelas = 36;
            var dataPrimeiroVencimento = Convert.ToDateTime("23/08/2020", new CultureInfo("pt-BR"));
            
            CreditoPessoaFisica creditoPessoaFisica = new CreditoPessoaFisica(new Credito<CreditoPessoaFisica>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoPessoaFisica.Taxa });

            CreditoVO creditoVOPessoaFisica = creditoPessoaFisica.Calcular();
            
            Console.WriteLine($"Status do Crédito: {creditoVOPessoaFisica.Status}\nValor Total Com Juros: R$ {creditoVOPessoaFisica.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOPessoaFisica.ValorJuros.ToString("#.##")}");
        }
    }
}
