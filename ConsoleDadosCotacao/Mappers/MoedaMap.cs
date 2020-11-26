using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDadosCotacao.Mappers
{
    public sealed class MoedaMap : ClassMap<DTO.Moeda>
    {
        public MoedaMap()
        {
            Map(x => x.ID_MOEDA).Name("ID_MOEDA");
            Map(x => x.DATA_REF).Name("DATA_REF");
        }
    }
}
