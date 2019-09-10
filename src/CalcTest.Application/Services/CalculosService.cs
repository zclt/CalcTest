using CalcTest.Application.Abstractions;
using CalcTest.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest.Application.Services
{
    public class CalculosService : ICalculosService
    {
        private readonly ITaxasService _taxaService;

        public CalculosService(ITaxasService taxaService)
        {
            _taxaService = taxaService;
        }

        public double CalculaJuros(double valoInicial, int meses)
        {
            if (valoInicial <= 0) throw new ArgumentException(nameof(valoInicial));
            if (meses <= 0) throw new ArgumentException(nameof(meses));

            var juros = _taxaService.GetTaxaJuros();
            var valorfinal = valoInicial * Math.Pow(1 + juros, meses);
            return valorfinal.Truncate();
        }
    }
}
