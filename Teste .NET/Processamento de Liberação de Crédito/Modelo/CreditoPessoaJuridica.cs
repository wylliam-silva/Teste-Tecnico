using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CreditoPessoaJuridica: ICreditoPessoaJuridica
    {
        #region Propriedades
        private const decimal ValorMinimoEmprestimo = 15000.00M;
        private readonly ICredito<CreditoPessoaJuridica> _creditoPessoaJuridica;
        public const decimal Taxa = 5;
     
        public decimal ValorTotalJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Construtores
        public CreditoPessoaJuridica(ICredito<CreditoPessoaJuridica> creditoPessoaJuridica)
        {
            _creditoPessoaJuridica = creditoPessoaJuridica;
        }
        #endregion

        #region Métodos
        public CreditoVO Calcular()
        {
            var resultado = _creditoPessoaJuridica.Calcular(this);

            if (ValidarValorMaximoEmprestimo().Equals(CreditoVO.StatusCredito.Reprovado))
                resultado.Status = CreditoVO.StatusCredito.Reprovado;

            return resultado;
        }

        private CreditoVO.StatusCredito ValidarValorMaximoEmprestimo()
        {
            if (ValorCredito < ValorMinimoEmprestimo)
                return CreditoVO.StatusCredito.Reprovado;
            else
                return CreditoVO.StatusCredito.Aprovado;
        }
        #endregion
    }
}
