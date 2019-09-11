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
            _taxasService.Setup(t => t.GetTaxaJuros()).Returns(0.01d);

            _service = new CalculosService(_taxasService.Object);
        }

        [Theory]
        [InlineData(100.00, 5, 105.10)]
        [InlineData(100.00, 9, 109.36)]
        [InlineData(100.00, 11, 111.56)]
        [InlineData(100.00, 48, 161.22)]
        public void CalcCalculaJurosTest(double valorInicial, int meses, double valorFinal)
        {
            //arrange
            //act
            var result = _service.CalculaJuros(valorInicial, meses);

            //assert
            Assert.Equal(valorFinal, result);
        }

        [Fact]
        public void CalcCalculaJurosZeroValuesTest()
        {
            //arrange & act & assert
            Assert.Throws<ArgumentException>(() => _service.CalculaJuros(100.00, 0));
            Assert.Throws<ArgumentException>(() => _service.CalculaJuros(0, 5));
        }

        [Fact]
        public void CalcCalculaJurosNegativeValuesTest()
        {
            //arrange & act & assert
            Assert.Throws<ArgumentException>(() => _service.CalculaJuros(-100.00, 5));
            Assert.Throws<ArgumentException>(() => _service.CalculaJuros(100.00, -5));
        }
    }
}
