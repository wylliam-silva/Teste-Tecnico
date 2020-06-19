using Modelo.Interface;
using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CreditoDireto: ICreditoDireto
    {
        #region Propriedades
        private readonly ICredito<CreditoDireto> _creditoDireto;
        public const decimal Taxa = 2;
      
        public decimal ValorTotalJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        #endregion

        #region Construtores
        public CreditoDireto(ICredito<CreditoDireto> creditoDireto)
        {
            _creditoDireto = creditoDireto;
        }
        #endregion

        #region Métodos
        public CreditoVO Calcular()
        {
            return _creditoDireto.Calcular(this);
        }
        #endregion
    }
}
