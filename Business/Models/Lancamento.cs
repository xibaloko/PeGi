using System;

namespace Business.Models
{
    public class Lancamento
    {
        public int IdLancamento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
