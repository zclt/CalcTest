using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalcTest.Application.InputModels
{
    public class CalculaJurosInputModel
    {
        [Required]
        [Range(1, double.MaxValue)]
        public double ValorInicial { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Meses { get; set; }
    }
}
