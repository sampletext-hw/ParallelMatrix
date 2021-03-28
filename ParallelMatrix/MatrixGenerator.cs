using System;

namespace ParralelMatrix
{
    public class MatrixGenerator
    {
        public static Matrix GenerateRandom(int size)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            Matrix result = new Matrix(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = random.Next(0, 100);
                }
            }

            return result;
        }

        public static Matrix GenerateIdentity(int size)
        {
            Matrix result = new Matrix(size);

            for (int i = 0; i < size; i++)
            {
                result[i, i] = 1;
            }

            return result;
        }
    }
}