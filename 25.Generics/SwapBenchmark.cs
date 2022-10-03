using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _25.Generics
{
    public class SwapBenchmark
    {
        [Benchmark]
        public void GenericSwapBenchmark()
        {
            // Implement your benchmark here
            double a = 1;
            double b = 2;
            SwapTestClass.GenericSwap(ref a, ref b);
        }

        [Benchmark]
        public void SwapBenchmark()
        {
            // Implement your benchmark here
            object a = 1;
            object b = 2;
            SwapTestClass.Swap(ref a, ref b);
        }
    }
}
