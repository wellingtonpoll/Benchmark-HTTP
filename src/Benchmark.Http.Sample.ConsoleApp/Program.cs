using BenchmarkDotNet.Running;
using System;

namespace Benchmark.Http.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
                BenchmarkHttp.DefaultURL = args;

            Console.WriteLine("Requesting URL: {0}", BenchmarkHttp.DefaultURL);
            BenchmarkRunner.Run<BenchmarkHttp>();
        }
    }
}
