using System;
using System.Threading;

namespace ParralelMatrix
{
    public class MultiCoreMultiplier : IMatrixMultiplier
    {
        public int Degree { get; set; }

        public MultiCoreMultiplier(int degree = 0)
        {
            Degree = degree;
        }

        public Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.Size != m2.Size)
            {
                throw new ArgumentException("Matrix sizes mismatch");
            }

            // Force only half of threads, if degree is not passed
            int degree = Degree == 0 ? Environment.ProcessorCount / 2 : Degree;

            // Get matrix size
            int size = m1.Size;

            // Total amount of matrix cells
            int totalCells = size * size;

            // Cells for one thread
            int cellsPerJob = totalCells / degree;

            // Result matrix
            Matrix result = new Matrix(size);

            // Array of thread jobs, which contains all required data
            ThreadJob[] jobs = new ThreadJob[degree];

            // Split all matrix operation into jobs of equal size
            for (var i = 0; i < jobs.Length; i++)
            {
                // job from start (index `i`) to end (index `i + 1`)
                jobs[i] = new ThreadJob(
                    m1, m2, result,
                    cellsPerJob * i,
                    cellsPerJob * (i + 1)
                );
            }

            // Start all jobs
            for (var i = 0; i < jobs.Length; i++)
            {
                jobs[i].Run();
            }

            // Wait some time so jobs can actually start
            Thread.Sleep(10);

            // Wait for all jobs to finish
            for (var i = 0; i < jobs.Length; i++)
            {
                jobs[i].Wait();
            }

            return result;
        }
    }
}