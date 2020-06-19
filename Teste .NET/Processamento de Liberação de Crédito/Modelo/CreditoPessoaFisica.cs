using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CreditoPessoaFisica: ICreditoPessoaFisica
    {
        #region Propriedades
        private readonly ICredito<CreditoPessoaFisica> _creditoPessaFisica;
        public const decimal Taxa = 3;
   
        public decimal ValorTotalJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Construtores
        public CreditoPessoaFisica(ICredito<CreditoPessoaFisica> creditoPessaFisica)
        {
            _creditoPessaFisica = creditoPessaFisica;
        }
        #endregion

        #region Métodos
        public CreditoVO Calcular()
        {
            return _creditoPessaFisica.Calcular(this);
        }
        #endregion
    }
}
