using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDadosCotacao.Mappers
{
    public sealed class CotacaoMap : ClassMap<DTO.Cotacao> 
    {
        public CotacaoMap()
        {
            Map(x => x.vlr_cotacao).Name("vlr_cotacao");
            Map(x => x.cod_cotacao).Name("cod_cotacao");
            Map(x => x.dat_cotacao).Name("dat_cotacao");
        }
    }
}
