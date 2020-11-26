using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleDadosCotacao.Services
{
    public class MoedaService
    {
        public List<DTO.Moeda> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.RegisterClassMap<Mappers.MoedaMap>();
                    var records = csv.GetRecords<DTO.Moeda>().ToList();
                    return records;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
