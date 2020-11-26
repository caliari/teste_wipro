using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDadosCotacao.Mappers
{
    public sealed class CompareMap : ClassMap<DTO.Compare>
    {
        public CompareMap()
        {
            Map(x => x.ID_MOEDA).Name("ID_MOEDA");
            Map(x => x.cod_cotacao).Name("cod_cotacao");
        }
    }
}
