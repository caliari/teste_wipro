using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleDadosCotacao.Services
{
    public class CotacaoService
    {
        public List<DTO.Cotacao> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.RegisterClassMap<Mappers.CotacaoMap>();
                    var records = csv.GetRecords<DTO.Cotacao>().ToList();
                    return records;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WriteCSVFile(string path, List<DTO.Cotacao> cotacaos)
        {

            using (var writer = new StreamWriter(path, false))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<DTO.Cotacao>();
                csv.NextRecord();
                csv.WriteRecords(cotacaos);
            }
        }
    }
}
