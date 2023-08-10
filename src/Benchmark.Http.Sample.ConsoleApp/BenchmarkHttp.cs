using System;
using System.Net.Http;
using System.Threading.Tasks;
using Benchmark.Http.Sample.ConsoleApp.Refit;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Flurl.Http;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using RestSharp;

namespace Benchmark.Http.Sample.ConsoleApp
{
    [MemoryDiagnoser]
    [AllStatisticsColumn]
    [RankColumn(NumeralSystem.Arabic)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [Config(typeof(AntiVirusFriendlyConfig))]
    // [HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]

    public class BenchmarkHttp
    {
        private IHttpClientFactory _HttpClientFactory;
        private const string Url = "http://localhost:5000/WeatherForecast";

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            var provider = services.BuildServiceProvider();

            _HttpClientFactory = provider.GetRequiredService<IHttpClientFactory>();

            services.AddRefitClient<ILocalhost>().ConfigureHttpClient(c => c.BaseAddress = new Uri(Url));
        }

        [Benchmark]
        public async Task<string> HttpClientWithFactory()
        {
            return await _HttpClientFactory.CreateClient().GetStringAsync(new Uri(Url));
        }

        [Benchmark]
        public async Task<string> HttpClientPlain()
        {
            return await new HttpClient().GetStringAsync(Url);
        }

        [Benchmark]
        public async Task<string> RestSharp()
        {
            var response = await new RestClient().ExecuteAsync(new RestRequest(Url, Method.Get));
            return response.Content;
        }

        [Benchmark]
        public async Task<string> Flurl()
        {
            return await Url.GetStringAsync();
        }

        [Benchmark]
        public async Task<string> Refit()
        {
            return await Url.GetStringAsync();
        }
    }
}