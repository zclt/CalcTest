using CalcTest.Application.Abstractions;
using CalcTest.Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalcTest.Test.Services
{
    public class CalculosServiceTest
    {
        private CalculosService _service;

        public CalculosServiceTest()
        {
            var _taxasService = new Mock<ITaxasService>();
            _taxasService.Setup(t => t.GetTaxaJuros()).Returns(0.01);

            _service = new CalculosService(_taxasService.Object);
        }

        [Fact]
        public void CalcCalculaJurosTest()
        {
            //arrange
            var valorInicial = 100.00;
            var meses = 5;

            //act
            var valorFinal = _service.CalculaJuros(valorInicial, meses);

            //assert
            Assert.Equal(105.10, valorFinal);
        }
    }
}
