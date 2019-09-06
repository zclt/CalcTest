using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest.Application.Abstractions
{
    public interface ICalculosService
    {
        double CalculaJuros(double valoInicial, int meses);
    }
}
