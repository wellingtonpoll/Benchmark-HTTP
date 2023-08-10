using Refit;
using System.Threading.Tasks;

namespace Benchmark.Http.Sample.ConsoleApp.Refit
{
    public interface ILocalhost
    {
        [Headers("Content-Type: application/json")]
        [Get("http://localhost:5000/WeatherForecast")]
        Task GetAsync();
    }
}