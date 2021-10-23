using System;
using BenchmarkDotNet.Running;

namespace Benchmark.Http.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkHttp>();
        }
    }
}
