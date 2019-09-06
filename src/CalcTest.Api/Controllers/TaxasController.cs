using CalcTest.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcTest.Api.Controllers
{
    /// <summary>
    /// API 1
    /// </summary>
    [Route("api/[controller]")]
    public class TaxasController : ControllerBase
    {
        private readonly ITaxasService _taxasService;

        public TaxasController(ITaxasService taxasService)
        {
            _taxasService = taxasService;
        }

        /// <summary>
        /// Retorna taxa de juros
        /// </summary>
        /// <returns></returns>
        [HttpGet("TaxaJuros")]
        public ActionResult GetTaxaJuros()
        {
            var taxa = _taxasService.GetTaxaJuros();
            return Ok(taxa.ToString("0.##"));
        }
    }
}
