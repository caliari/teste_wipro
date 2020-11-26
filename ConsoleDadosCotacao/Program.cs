using CsvHelper;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;

namespace ConsoleDadosCotacao
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 120000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();   
        }

        private static void TimerCallback(Object o)
        {
            Console.WriteLine("API...");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var jsonString = client.GetStringAsync("https://localhost:44333/api/ItemEntities/GetItemFila").GetAwaiter().GetResult();

            ItemEntity item = JsonSerializer.Deserialize<ItemEntity>(jsonString);
            if (!string.IsNullOrEmpty(item.moeda))
            {
                Console.WriteLine("Lendo o CSV...");

                var _moedaService = new Services.MoedaService();
                var path = "Files\\DadosMoeda.csv";

                var resultDataM = _moedaService.ReadCSVFile(path);

                List<DTO.Moeda> Moedas = resultDataM.ToList().Where(x => x.ID_MOEDA == item.moeda &&
                                                                                Convert.ToDateTime(Convert.ToDateTime(x.DATA_REF).ToString("dd/MM/yyyy")) >= item.data_inicio &&
                                                                                Convert.ToDateTime(Convert.ToDateTime(x.DATA_REF).ToString("dd/MM/yyyy")) <= item.data_fim).ToList();

                foreach(DTO.Moeda moeda in Moedas)
                {

                    var _compareService = new Services.CompareService();
                    path = "Files\\DE_PARA.csv";

                    var resultDataCompare = _compareService.ReadCSVFile(path);

                    DTO.Compare comparacao = resultDataCompare.ToList().Where(x => x.ID_MOEDA == moeda.ID_MOEDA).ToList().FirstOrDefault();

                    var _cotacaoService = new Services.CotacaoService();
                    path = "Files\\DadosCotacao.csv";

                    var resultDataC = _cotacaoService.ReadCSVFile(path);


                    List<DTO.Cotacao> cotacoes = resultDataC.ToList().Where(x => x.cod_cotacao == comparacao.cod_cotacao &&
                                                                               Convert.ToDateTime(Convert.ToDateTime(x.dat_cotacao).ToString("dd/MM/yyyy")) >= item.data_inicio &&
                                                                               Convert.ToDateTime(Convert.ToDateTime(x.dat_cotacao).ToString("dd/MM/yyyy")) <= item.data_fim).ToList();

                    var pathWrite = "Files\\Resultado_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + ".csv";
                    _cotacaoService.WriteCSVFile(pathWrite, cotacoes);
                }

                Console.WriteLine(jsonString);

            }
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}
