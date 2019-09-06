using CalcTest.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest.Application.Services
{
    public class TaxasService : ITaxasService
    {
        private readonly double _taxa = 0.01d;

        public double GetTaxaJuros()
        {
            return _taxa;
        }
    }
}
