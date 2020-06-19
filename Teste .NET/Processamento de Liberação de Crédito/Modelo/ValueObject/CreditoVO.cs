using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ValueObject
{
    public class CreditoVO
    {
        public enum StatusCredito : byte
        {
            Aprovado = 1,
            Reprovado = 0
        };
        public StatusCredito Status { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ValorJuros { get; set; }
    }
}
