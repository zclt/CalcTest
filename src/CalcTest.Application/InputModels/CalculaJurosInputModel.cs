using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalcTest.Application.InputModels
{
    public class CalculaJurosInputModel
    {
        [Required]
        public double ValorInicial { get; set; }
        [Required]
        public int Meses { get; set; }
    }
}
