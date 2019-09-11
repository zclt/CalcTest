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
    public class TaxasTest
    {
        private readonly TestContext _testContext;

        public TaxasTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_GetTaxaJuros_ValuesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/Taxas/TaxaJuros");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetTaxaJuros_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/api/Taxas/TaxaJuros");
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}
