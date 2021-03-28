using System;
using System.Diagnostics;

namespace ParralelMatrix
{
    public class TimeMeasurer
    {
        public static long Measure(Action task)
        {
            Stopwatch sw = Stopwatch.StartNew();
            task.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}