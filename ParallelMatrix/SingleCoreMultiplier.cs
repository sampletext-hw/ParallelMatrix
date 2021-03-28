using System;

namespace ParralelMatrix
{
    public class SingleCoreMultiplier : IMatrixMultiplier
    {
        public Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.Size != m2.Size)
            {
                throw new ArgumentException("Matrix sizes mismatch");
            }

            int size = m1.Size;

            Matrix result = new Matrix(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }
    }
}