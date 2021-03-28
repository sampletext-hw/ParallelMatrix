using System;
using System.Diagnostics;

namespace ParralelMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSingle(100);
            Test(100, 4);
            Test(100, 8);
            Test(100, 16);
            
            TestSingle(500);
            Test(500, 4);
            Test(500, 8);
            Test(500, 16);
            
            TestSingle(1000);
            Test(1000, 4);
            Test(1000, 8);
            Test(1000, 16);
        }

        private static void Test(int size, int degree = 0)
        {
            Console.WriteLine($"Measuring MultiThread Size of {{{size}}} and degree {{{degree}}}");

            var elapsed = PerformTest(size, new MultiCoreMultiplier(degree));

            Console.WriteLine($"Operation elapsed in: {elapsed} ms");
        }

        private static void TestSingle(int size)
        {
            Console.WriteLine($"Measuring SingleThread Size of {{{size}}}");

            var elapsed = PerformTest(size, new SingleCoreMultiplier());

            Console.WriteLine($"Operation elapsed in: {elapsed} ms");
        }

        private static long PerformTest(int size, IMatrixMultiplier multiplier)
        {
            var matrix = MatrixGenerator.GenerateRandom(size);

            //Console.WriteLine("Source:\n" + matrix);

            var identity = MatrixGenerator.GenerateIdentity(size);

            //Console.WriteLine("Identity:\n" + identity);

            var elapsed = TimeMeasurer.Measure(() => { multiplier.Multiply(matrix, identity); });

            //Console.WriteLine("Result:\n" + result);

            return elapsed;
        }
    }
}