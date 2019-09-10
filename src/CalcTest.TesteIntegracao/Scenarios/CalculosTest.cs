using CalcTest.TesteIntegracao.Fixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalcTest.TesteIntegracao.Scenarios
{
    public class CalculosTest
    {
        private readonly TestContext _testContext;

        public CalculosTest()
        {
            _testContext = new TestContext();
        }

        [Theory]
        [InlineData(100.00, 5)]
        [InlineData(900.50, 100)]
        public async Task Values_GetCalculaJuros_ReturnsOkResponse(double valorInicial, int meses)
        {
            var response = await _testContext.Client.GetAsync($"/api/Calculos/CalculaJuros?ValorInicial={valorInicial}&Meses={meses}");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(100.00, 5, "105,10")]
        [InlineData(100.00, 6, "106,15")]
        [InlineData(100.00, 7, "107,21")]
        public async Task Values_GetCalculaJuros_ReturnsValue(double valorInicial, int meses, string valorFinal)
        {
            var response = await _testContext.Client.GetAsync($"/api/Calculos/CalculaJuros?ValorInicial={valorInicial}&Meses={meses}");
            response.EnsureSuccessStatusCode();
            var s = response.Content.ReadAsStringAsync().Result;
            response.Content.ReadAsStringAsync().Result.Should().Be(valorFinal);
        }

        [Theory]
        [InlineData(100.00, 5)]
        public async Task Values_GetCalculaJuros_CorrectContentType(double valorInicial, int meses)
        {
            var response = await _testContext.Client.GetAsync($"/api/Calculos/CalculaJuros?ValorInicial={valorInicial}&Meses={meses}");
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        public async Task Values_GetCalculaJuros_ReturnsBadRequestResponse(double valorInicial, int meses)
        {
            var response = await _testContext.Client.GetAsync($"/api/Calculos/CalculaJuros?ValorInicial={valorInicial}&Meses={meses}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Values_GetCalculaJurosSemParams_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync($"/api/Calculos/CalculaJuros?ValorInicial=&Meses=");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
