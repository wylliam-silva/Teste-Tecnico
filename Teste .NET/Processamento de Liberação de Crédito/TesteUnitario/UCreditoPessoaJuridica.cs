using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Modelo.ValueObject;

namespace TesteUnitario
{
    [TestClass]
    public class UCreditoPessoaJuridica
    {
        [TestMethod]
        public void Calcular()
        {
            var valorCredito = 1000000000.00M;
            var quantidadeParcelas = 36;
            var dataPrimeiroVencimento = Convert.ToDateTime("23/08/2020", new CultureInfo("pt-BR"));

            CreditoPessoaJuridica creditoPessoaJuridica = new CreditoPessoaJuridica(new Credito<CreditoPessoaJuridica>() { ValorCredito = valorCredito, QuantidadeParcelas = quantidadeParcelas, DataPrimeiroVencimento = dataPrimeiroVencimento, Taxa = CreditoPessoaJuridica.Taxa });

            creditoPessoaJuridica.ValorCredito = valorCredito;

            CreditoVO creditoVOPessoaJuridica = creditoPessoaJuridica.Calcular();
            
            Console.WriteLine($"Status do Crédito: {creditoVOPessoaJuridica.Status}\nValor Total Com Juros: R$ {creditoVOPessoaJuridica.ValorTotalComJuros.ToString("#.##")}\nValor do Juros: R$ {creditoVOPessoaJuridica.ValorJuros.ToString("#.##")}");
        }
    }
}
