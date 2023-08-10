using BenchmarkDotNet.Running;

namespace Benchmark.Http.Sample.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchmarkHttp>();
        }
    }
}
