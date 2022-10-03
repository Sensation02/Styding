using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace _23.Boxing_unboxing
{
    public class BoxingTest
    {
        [Benchmark]
        public void NoBoxing() //швидше
        {
            int res = 0;
            int a = 1;
            res += a;
        }

        [Benchmark]
        public void Boxing() //довше
        {
            int res = 0;
            object a = 1;
            res += (int)a;
        }
    }
}