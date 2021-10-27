using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Flurl.Http;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace Benchmark.Http.Sample.ConsoleApp
{
    [MemoryDiagnoser]
    [AllStatisticsColumn]
    [RankColumn(NumeralSystem.Arabic)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
   // [HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]

    public class BenchmarkHttp
    {
        private IHttpClientFactory _HttpClientFactory;

        public static string[] DefaultURL { get; set; } = new[] { "http://localhost:5000/WeatherForecast" };

        [ParamsSource(nameof(DefaultURL))]
        public string Url { get; set; }


        [GlobalSetup]
        public void Setup()
        {

            var services = new ServiceCollection();
            services.AddHttpClient();
            var provider = services.BuildServiceProvider();

            _HttpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
        }


        [Benchmark]
        public async Task<string> HttpClientWithFactory()
        {
            return await _HttpClientFactory.CreateClient().GetStringAsync(Url);
        }

        [Benchmark]
        public async Task<string> HttpClientPlain()
        {
            return await new HttpClient().GetStringAsync(Url);
        }

        [Benchmark]
        public async Task<string> RestSharp()
        {
            var response = await new RestClient(Url).ExecuteAsync(new RestRequest(Method.GET));
            return response.Content;
        }

        [Benchmark]
        public async Task<string> Flurl()
        {
            return await Url.GetStringAsync();
        }
    }
}