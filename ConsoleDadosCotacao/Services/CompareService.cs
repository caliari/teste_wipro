using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleDadosCotacao.Services
{
    public class CompareService
    {
        public List<DTO.Compare> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.RegisterClassMap<Mappers.CompareMap>();
                    var records = csv.GetRecords<DTO.Compare>().ToList();
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
