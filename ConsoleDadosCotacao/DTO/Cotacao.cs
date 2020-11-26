using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDadosCotacao.DTO
{
    public class Cotacao
    {
        public string vlr_cotacao { get; set; }
        public int cod_cotacao { get; set; }
        public string dat_cotacao { get; set; }
    }
}
