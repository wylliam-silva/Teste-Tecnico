using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Credito<T> : ICredito<T>
    {
        #region Propriedades
        private const decimal ValorMaximoEmprestimo = 1000000.00M;

        private const int QuantidadeMaximaParcelas = 76;

        private const int QuantidadeMinimaParcelas = 5;

        private DateTime DataMinimaPrimeiroVencimento = DateTime.UtcNow.AddDays(15);

        private DateTime DataMaximaPrimeiroVencimento = DateTime.UtcNow.AddDays(40);

        public decimal Taxa { get; set; }
        private decimal ValorTotalJuros { get; set; }
        private decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Método para calcular o valor de crédito com juros e valor dos juros
        /// </summary>
        /// <param name="Credito"></param>
        /// <returns>Retorna um objeto com o Valor Total do Crédito Com Juros, Valor do Juros e Status(Aprovado ou Reprovado)</returns>
        public CreditoVO Calcular(T Credito)
        {
            return new CreditoVO()
            {
                ValorTotalComJuros = CalcularValorTotalComJuros(),
                ValorJuros = decimal.Round(CalcularValorJuros(), 2, MidpointRounding.AwayFromZero),
                Status = ValidarLiberacaoCredito()
            };
        }

        /// <summary>
        /// Método para calcular o valor total do credito solicitado + juros
        /// </summary>
        /// <returns>Retorna Valor Total do Crédito solicitado com juros em formato decimal</returns>
        private decimal CalcularValorTotalComJuros()
        {
            return ValorCredito + ((Taxa * ValorCredito) / 100);
        }

        /// <summary>
        /// Método para calcular o valor dos juros sobre o valor de crédito solicitado
        /// </summary>
        /// <returns>retorna o valor de juros sobre o crédito solicitado com tipo decimal</returns>
        private decimal CalcularValorJuros()
        {
            return ((Taxa * ValorCredito) / 100);
        }

        /// <summary>
        /// Método para Validar a Liberação de Crédito com várias regras de negócio
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarLiberacaoCredito()
        {
            if (ValidarValorMaximoEmprestimo().Equals(CreditoVO.StatusCredito.Reprovado))
                return CreditoVO.StatusCredito.Reprovado;

            if (ValidarQuantidadeMaximaParcelas().Equals(CreditoVO.StatusCredito.Reprovado))
                return CreditoVO.StatusCredito.Reprovado;

            if (ValidarQuantidadeMinimaParcelas().Equals(CreditoVO.StatusCredito.Reprovado))
                return CreditoVO.StatusCredito.Reprovado;

            if (ValidarDataMinimaPrimeiroVencimento().Equals(CreditoVO.StatusCredito.Reprovado))
                return CreditoVO.StatusCredito.Reprovado;

            if (ValidarDataMaximaPrimeiroVencimento().Equals(CreditoVO.StatusCredito.Reprovado))
                return CreditoVO.StatusCredito.Reprovado;

            return CreditoVO.StatusCredito.Aprovado;
        }

        /// <summary>
        /// Método para validar o valor máximo de crédito permitido para liberação
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarValorMaximoEmprestimo()
        {
            if (ValorCredito > ValorMaximoEmprestimo)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }

        /// <summary>
        /// Método para validar a quantidade máxima de parcelas permitidas
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarQuantidadeMaximaParcelas()
        {
            if (QuantidadeParcelas > QuantidadeMaximaParcelas)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }

        /// <summary>
        /// Método para validar a quantidade mínima de parcelas permitidas
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarQuantidadeMinimaParcelas()
        {
            if (QuantidadeParcelas < QuantidadeMinimaParcelas)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }

        /// <summary>
        /// Método para validar a data mínima permitida para primeiro vencimento
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarDataMinimaPrimeiroVencimento()
        {
            if (DataPrimeiroVencimento < DataMinimaPrimeiroVencimento)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }

        /// <summary>
        /// Método para validar a data máxima permitida para primeiro vencimento
        /// </summary>
        /// <returns>retorna o status de crédito(aprovado ou reprovado)</returns>
        private CreditoVO.StatusCredito ValidarDataMaximaPrimeiroVencimento()
        {
            if (DataPrimeiroVencimento > DataMaximaPrimeiroVencimento)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }
        #endregion
    }
}
