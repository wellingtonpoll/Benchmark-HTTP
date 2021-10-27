using BenchmarkDotNet.Running;
using System;

namespace Benchmark.Http.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkHttp>();

            Console.WriteLine(summary);
            Console.ReadKey();
        }
    }
}
