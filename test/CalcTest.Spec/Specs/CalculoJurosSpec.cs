using CalcTest.Application.Abstractions;
using CalcTest.Application.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CalcTest.Spec.Specs
{
    [Binding]
    [Scope(Feature = "Calcula juros")]
    public class CalculoJurosSpec
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CalculosService _calculosService;

        private double _valorInicial;
        private int _meses;
        private double _valorFinal;

        public CalculoJurosSpec(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            var taxaService = new Mock<ITaxasService>();
            taxaService.Setup(t => t.GetTaxaJuros()).Returns(0.01d);

            _calculosService = new CalculosService(taxaService.Object);
        }

        [Given(@"Um valor inicial (.*)")]
        public void GivenUmValorInicial(double p0)
        {
            _scenarioContext.Add(nameof(_valorInicial), p0);
        }

        [Given(@"Uma quantidade de meses (.*)")]
        public void GivenUmaQuantidadeDeMeses(int p0)
        {
            _scenarioContext.Add(nameof(_meses), p0);
        }

        [When(@"Calcular o valor de juros")]
        public void WhenCalcularOValorDeJuros()
        {
            _scenarioContext.TryGetValue(nameof(_valorInicial), out _valorInicial);
            _scenarioContext.TryGetValue(nameof(_meses), out _meses);
            _valorFinal = _calculosService.CalculaJuros(_valorInicial, _meses);
            _scenarioContext.Add(nameof(_valorFinal), _valorFinal);
        }

        [Then(@"O resultado deve ser (.*)")]
        public void ThenOResultadoDeveSer(double p0)
        {
            _scenarioContext.TryGetValue(nameof(_valorFinal), out _valorFinal);
            Assert.AreEqual(p0, _valorFinal);
        }

    }
}
