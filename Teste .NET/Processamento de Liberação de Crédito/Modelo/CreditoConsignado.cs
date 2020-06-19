using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CreditoConsignado : ICreditoConsignado
    {
        #region Propriedades
        private readonly ICredito<CreditoConsignado> _creditoConsignado;
        public const decimal Taxa = 1;
       
        public decimal ValorTotalJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Construtores
        public CreditoConsignado(ICredito<CreditoConsignado> creditoConsignado)
        {
            _creditoConsignado = creditoConsignado;
        }
        #endregion

        #region Métodos
        public CreditoVO Calcular()
        {
            return _creditoConsignado.Calcular(this);
        }
        #endregion
    }
}
