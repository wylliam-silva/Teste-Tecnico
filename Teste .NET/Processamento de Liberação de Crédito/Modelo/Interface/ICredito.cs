using Modelo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Interface
{
    public interface ICredito<T>
    {
        CreditoVO Calcular(T Credito);
    }
}
