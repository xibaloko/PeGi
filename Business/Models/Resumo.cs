using System;

namespace Business.Models
{
    public class Resumo
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string TipoLancamento { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
