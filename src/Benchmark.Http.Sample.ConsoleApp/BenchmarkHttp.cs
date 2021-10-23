using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Flurl.Http;
using RestSharp;

namespace Benchmark.Http.Sample.ConsoleApp
{
    [MemoryDiagnoser]
    [AllStatisticsColumn]
    [RankColumn(NumeralSystem.Arabic)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
    
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