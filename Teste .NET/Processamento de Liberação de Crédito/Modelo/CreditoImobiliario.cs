using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CreditoImobiliario: ICreditoImobiliario
    {
        #region Propriedades
        private readonly ICredito<CreditoImobiliario> _creditoImobiliario;
        public const decimal Taxa = 9;
     
        public decimal ValorTotalJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Construtores
        public CreditoImobiliario(ICredito<CreditoImobiliario> creditoImobiliario)
        {
            _creditoImobiliario = creditoImobiliario;
        }
        #endregion

        #region Métodos
        public CreditoVO Calcular()
        {
            return _creditoImobiliario.Calcular(this);
        }
        #endregion
    }
}
