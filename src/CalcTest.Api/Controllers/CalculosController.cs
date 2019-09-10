using CalcTest.Application.Abstractions;
using CalcTest.Application.InputModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcTest.Api.Controllers
{
    /// <summary>
    /// API 2
    /// </summary>
    [Route("api/[controller]")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculosService _calculosService;

        public CalculosController(ICalculosService calculosService)
        {
            _calculosService = calculosService;
        }

        /// <summary>
        /// Calcula Juros
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("CalculaJuros")]
        public ActionResult CalculaJuros([FromQuery] CalculaJurosInputModel input)
        {
            try
            {
                var valorFinal = _calculosService.CalculaJuros(input.ValorInicial, input.Meses);
                return Ok(valorFinal.ToString("0.00"));
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Show me the code
        /// </summary>
        /// <returns></returns>
        [HttpGet("ShowMeTheCode")]
        public ActionResult ShowMeTheCode()
        {
            return Ok("https://github.com/zclt/CalcTest");
        }
    }
}
