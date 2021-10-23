using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Flurl.Http;
using Perfolizer.Mathematics.OutlierDetection;
using RestSharp;

namespace Benchmark.Http.Sample.ConsoleApp
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Arabic)]
    public class BenchmarkHttp
    {
        private readonly string _url = "http://localhost:5000/WeatherForecast";

        [Benchmark]
        public async Task<string> HttpClient()
        {
            return await new HttpClient().GetStringAsync(_url);
        }

        [Benchmark]
        public async Task<string> RestSharp()
        {
            var response = await new RestClient(_url).ExecuteAsync(new RestRequest(Method.GET));
            return response.Content;
        }

        [Benchmark]
        public async Task<string> Flurl()
        {
           return await _url.GetStringAsync();
        }
    }
}